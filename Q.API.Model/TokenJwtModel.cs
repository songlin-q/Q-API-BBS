using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Model
{
    /// <summary>
    /// Jwtmodel
    /// </summary>
    public class TokenJwtModel
    { 
        /// <summary>
        /// 用户ID
        /// </summary>
        public long uID { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string department { get; set; }
    }
}
