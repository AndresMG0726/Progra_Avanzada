using System.Collections.Generic;

namespace BE.API.DataModels
{
    public class Categories
    {

            public Categories()
            {
            }

            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
            public byte[] Picture { get; set; }


    }
    
}
