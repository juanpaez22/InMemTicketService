using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using TicketDataService.Models;

namespace TicketDataService.DataSource
{
	public class ContactDataSource
	{
		private static ContactDataSource instance = null;
		private static Dictionary<Guid, Contact> contactDict = null;

		public static ContactDataSource Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ContactDataSource();
				}
				return instance;
			}
		}

		public IQueryable<Contact> Contacts
		{
			get
			{
				if (contactDict == null)
                {
					contactDict = new Dictionary<Guid, Contact>();
					var json = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\contacts.txt");
					var deserialized = JsonConvert.DeserializeObject<Contact[]>(json);
					foreach (Contact c in deserialized)
                    {
						contactDict.Add(c.ContactID, c);
                    }
				}

				return contactDict.Select(x => x.Value).AsQueryable();

			}
		}

		public void InsertContact(Contact c)
        {
			contactDict.Add(c.ContactID, c);
        }

		public void DeleteContact(Contact c)
        {
			contactDict.Remove(c.ContactID);
        }

		public Contact GetContact(Guid id)
        {
			return contactDict[id];
        }
	}

	internal class Contacts
	{
		public List<Contact> Items { get; set; }
	}
}
