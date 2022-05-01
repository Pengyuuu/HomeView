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

        public async Task<int> AsyncGetActorInfo ( ActWiki actor )
        {
<<<<<<< HEAD
            var searchActor = new
=======
            /* Commenting out so I can build 
            var searchActor = new

            
            var newActor = new

>>>>>>> d18130b0c61d4e0e5a5d163320b662c5954d0918
            {
                actName = actor.actName,
                actBirth = actor.actBirth,
                actGender = actor.actGender,
<<<<<<< HEAD
            };

            return await _db.SaveData("dbo.ActorSearched", searchActor);
=======


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
>>>>>>> d18130b0c61d4e0e5a5d163320b662c5954d0918

        }
    }
}
