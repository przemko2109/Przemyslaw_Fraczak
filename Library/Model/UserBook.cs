using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Models
{
    public class UserBook
    {
        public UserBook(int id)
        {
            UserBookId = id;
            UserBookBookId = DataService.getBookId(id);
            UserBookUserId = DataService.getUserId(id);
        }
        public int UserBookId { get; set; }
        public int UserBookBookId { get; set; }
        public int UserBookUserId { get; set; }
    }
}
