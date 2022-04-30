using System.Collections.Generic;
﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Features.ActWiki
{
    public class ActWikiDao
    {
        private readonly SqlDataAccess _db;
        
        public ActWikiDao( SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AsyncGetActorInfo ( ActWiki actor )
        {
            /* Commenting out so I can build 
            var searchActor = new

            
            var newActor = new

            {
                actName = actor.actName,
                actBirth = actor.actBirth,
                actGender = actor.actGender,


            };
            try
            {
                await _db.SaveData("dbo.SearchActor", searchActor);
                return true;
            }
            catch 
            {
                return false;
            }
        

            };*/
            return false;

        }
    }
}
