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

        public async Task<int> AsyncGetActorInfo ( ActWiki actor )
        {
            var searchActor = new
            {
                actName = actor.actName,
                actBirth = actor.actBirth,
                actGender = actor.actGender,
            };

            return await _db.SaveData("dbo.ActorSearched", searchActor);

        }
    }
}
