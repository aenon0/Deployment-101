using Application.Contracts.GroupFormation;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.GroupRepo
{
    internal class GroupRepository : IGroupRepository
    {
        ContestCentralDbContext _contestCentralDbContext;
        public GroupRepository(ContestCentralDbContext contestCentralDbContext)
        {

            _contestCentralDbContext = contestCentralDbContext;

        }
        public async Task<Group> GetGroupByName(string name)
        {
            var group = await _contestCentralDbContext.Groups.FirstOrDefaultAsync(g => g.Name == name);
            return group;
        }
    }
}
