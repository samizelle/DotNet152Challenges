using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimRepository
    {
        Queue<Claim> _claimsQueue = new Queue<Claim>();

        public void AddClaimToQueue(Claim claim)
        {
            _claimsQueue.Enqueue(claim);
        }

        public Queue<Claim> GetClaims()
        {
            return _claimsQueue;
        }

    }
}