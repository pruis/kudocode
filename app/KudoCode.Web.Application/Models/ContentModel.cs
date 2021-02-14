using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudoCode.Web.Application.Models
{
    public class ContentModel
    {
	    public ContentModel()
	    {
		    Template = "EmptyTemplate";
	    }

	    public string Template { get; set; }
    }
}
