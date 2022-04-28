<<<<<<< HEAD
﻿using System.Collections.Generic;
=======
﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
>>>>>>> 5fe1b6b8fa68adc322adea14f5088bcf1b114003
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
<<<<<<< HEAD
            var searchActor = new
=======
            /* Commenting out so I can build 
            var newActor = new
>>>>>>> 5fe1b6b8fa68adc322adea14f5088bcf1b114003
            {
                actName = actor.actName,
                actBirth = actor.actBirth,
                actGender = actor.actGender,

<<<<<<< HEAD
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
        
=======
            };*/
            return false;
>>>>>>> 5fe1b6b8fa68adc322adea14f5088bcf1b114003
        }
    }
}
