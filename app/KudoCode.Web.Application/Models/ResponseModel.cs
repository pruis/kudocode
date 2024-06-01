using System.Collections.Generic;
using KudoCode.Contracts;
using KudoCode.Contracts;
using KudoCode.Contracts.Web;

namespace KudoCode.Web.Application.Models
{
    public class ResponseModel<T> 
    {
		public ResponseModel()
		{
			Errors = new List<MessageDto>();
			Messages = new List<MessageDto>();
		}

		public ResponseRedirect Redirect { get; set; }
	    public List<MessageDto> Errors { get; set; }
	    public List<MessageDto> Messages { get; set; }
	    public T Result { get; set; }

	    public void SetRedirect(string action, string actionValue, string title)
	    {
			Redirect = new ResponseRedirect(actionValue,action,title);
	    }
    }
}
