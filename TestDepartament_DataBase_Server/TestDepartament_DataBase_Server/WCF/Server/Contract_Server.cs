using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using bzgd_dr.EntityFramework.Contexts;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF.ConnectionDataTypes;
using bzgd_dr.WCF;


namespace bzgd_dr.WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    class ServerContract : IContract
    {
        public bool authentificated = false;

        DataModelContext db;

        public ServerContract()
        {
            db = new DataModelContext();
        }

        public string LoginOfUser = null;

        public bool Registrate(string log, string pass)
        {
            if (db.Users.FirstOrDefault(i => i.login == log) != null)
            {
                return false;
            }
            User newUser = new User();
            newUser.login = log;
            newUser.passHash = pass;

            db.Users.Add(newUser);
            db.SaveChanges();

            return true;
        }

        public bool TryAuthentificate(string log, string pass)
        {
            authentificated = db.Users.FirstOrDefault((i) => (i.login == log && i.passHash == pass)) != null;

            if (authentificated)
            {
                authentificated = true;
                LoginOfUser = log;
            }

            return authentificated;
        }

        public ShortRequestWithAttachmentsList GetShortRequests(RequestsSearchFilter filter)
        {
            if (!authentificated)
            {
                throw new Exception();
            }

            if (LoginOfUser == null)
            {
                throw new Exception();
            }

            List<Request> res1 = filter.FiltredCollection(db.Requests).Where(i => (i.login_senderId == LoginOfUser || i.login_recieverId == LoginOfUser)).ToList();

            List<ShortRequestWithAttachments> res2 = res1.Select((x) =>
            new ShortRequestWithAttachments(x, db.AttachmentDatas.Where(i => i.RequestId == x.Id).Select((i) => new ShortAttachmentData()
            {
                id = i.id,
                AttachmentTypeId = i.AttachmentTypeId,
                FileName = i.FileName,
                ordinalNumber = i.ordinalNumber,
                RequestId = i.RequestId
            }).ToList())).ToList().ToArray().Select(i => i).ToList();

            ShortRequestWithAttachmentsList result = new ShortRequestWithAttachmentsList();
            result.ShortRequestWithAttachments = res2;

            return result;
        }

        public LongRequestWithAttachments GetLongRequest(int id)
        {
            Request baseRequest = db.Requests.FirstOrDefault(i => i.Id == id);

            if (baseRequest.login_recieverId != LoginOfUser && baseRequest.login_senderId != LoginOfUser)
            {
                throw new Exception();
            }

            List<AttachmentData> resultList = db.AttachmentDatas.Where(i => i.RequestId == id).ToList();

            return new LongRequestWithAttachments(baseRequest, resultList);
        }

		public AttachmentData GetAttachment(int id)
		{
			AttachmentData result = db.AttachmentDatas.FirstOrDefault(i => i.id == id);
			return result;
		}

		public RequestWithAttachments GetRequestWithAttachments(int id)
        {
            if (!authentificated)
                throw new Exception();

            Request res = db.Requests.FirstOrDefault(i => i.Id == id);

            if (res == null || res.login_senderId != LoginOfUser)
                throw new Exception();

            RequestWithAttachments result = new RequestWithAttachments(res, db.AttachmentDatas.Where(i => i.RequestId == res.Id).ToList());

            return result;
        }

        public bool AddRequest(RequestWithAttachments requestWithAttachments)
        {
            if (requestWithAttachments.Request.login_senderId != LoginOfUser || !authentificated)
            {
                throw new Exception();
            }

            db.Requests.Add(requestWithAttachments.Request);
            db.SaveChanges();

            if(requestWithAttachments.attachmentList != null && requestWithAttachments.attachmentList.Count != 0)
            {
                for(int x = 0; x< requestWithAttachments.attachmentList.Count; x++)
                {
                    requestWithAttachments.attachmentList[x].ordinalNumber = x;
                    requestWithAttachments.attachmentList[x].RequestId = requestWithAttachments.Request.Id;
                    db.AttachmentDatas.Add(requestWithAttachments.attachmentList[x]);
                }
            }
            db.SaveChanges();


            return true;
        }

		public bool RemoveRequest(ShortRequestWithAttachments requestWithAttachments)
		{
			if (requestWithAttachments.Request.login_senderId != LoginOfUser || !authentificated)
			{
				throw new Exception();
			}
			db.Requests.Remove(db.Requests.First(i => i.Id == requestWithAttachments.Request.Id));
			db.SaveChanges();

			return true;
		}

		public bool ChangeRequestData(Request newRequest)
        {
            Request oldRequest = db.Requests.FirstOrDefault(i => i.Id == newRequest.Id);

            if (oldRequest == null || (oldRequest.login_senderId != LoginOfUser && oldRequest.login_recieverId != LoginOfUser) || !authentificated)
            {
                throw new Exception();
            }

            if (oldRequest.caption != newRequest.caption && oldRequest.caption != null)
                oldRequest.caption = newRequest.caption;

            if (oldRequest.hasAttachments != newRequest.hasAttachments && oldRequest.hasAttachments != null)
                oldRequest.hasAttachments = newRequest.hasAttachments;

            if (oldRequest.date_from != newRequest.date_from && oldRequest.date_from != null)
                oldRequest.date_from = newRequest.date_from;

            if (oldRequest.date_to != newRequest.date_to && oldRequest.date_to != null)
                oldRequest.date_to = newRequest.date_to;
			if(oldRequest.recourse != newRequest.recourse && oldRequest.recourse != null)
				oldRequest.recourse = newRequest.recourse;
			if (oldRequest.RequestStatusId != newRequest.RequestStatusId && oldRequest.RequestStatusId != null)
				oldRequest.RequestStatusId = newRequest.RequestStatusId;
			db.SaveChanges();

            return true;
        }

		public bool AddAttachment(AttachmentData attachmentData)
		{
			db.AttachmentDatas.Add(attachmentData);
			db.SaveChanges();
			return true;
		}

		public bool RemoveAttachment(ShortAttachmentData attachmentData)
		{
			db.AttachmentDatas.Remove(db.AttachmentDatas.First(i => i.id == attachmentData.id));
			db.SaveChanges();
			return false;
		}

		public ListOfShortAttachments GetAttachmentsList()
		{
			var shortAttachmentDatas = db.AttachmentDatas.Select(i =>
				new ShortAttachmentData()
				{
					AttachmentTypeId = i.AttachmentTypeId,
					FileName = i.FileName,
					id = i.id,
					ordinalNumber = i.ordinalNumber,
					RequestId = i.RequestId
				}
			).ToList();

			ListOfShortAttachments result = new ListOfShortAttachments();
			result.ShortAttachmentList = shortAttachmentDatas;

			return result;
		}

		public void Deauthentificate()
        {
            LoginOfUser = null;
            authentificated = false;

            db = new DataModelContext();
        }
    }
}