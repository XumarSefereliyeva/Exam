using ImtahanProyekt.BL.Exceptions;
using ImtahanProyekt.BL.ViewModels;
using ImtahanProyekt.DAL.Contexts;
using ImtahanProyekt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImtahanProyekt.BL.Services
{
    public  class TeamService
    {
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context)
        {
            _context = context;
        }
        public void Create(TeamCreateVM teamCreateVM)
        {
            Team team = new Team();
            team.Name = teamCreateVM.Name;
            team.Position= teamCreateVM.Position;
           if(team is not null)
            {
                string FileName = Path.GetFileNameWithoutExtension(teamCreateVM.ImgFile.FileName);
                string extension = Path.GetExtension(teamCreateVM.ImgFile.FileName);
                string FullName = FileName + Guid.NewGuid().ToString() + extension;
                team.ImgUrl = FullName;

                string UploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "UploadedImages");
                if (!Directory.Exists(UploadPath))
                {
                    Directory.CreateDirectory(UploadPath);
                }
                UploadPath = Path.Combine(UploadPath, FullName);
                using FileStream stream = new FileStream(UploadPath, FileMode.Create);
                teamCreateVM.ImgFile.CopyTo(stream);

                _context.teams.Add(team);
            }
            
            _context.SaveChanges();
        }
        public List<Team> GetAllteam()
        {
            List<Team> teams = _context.teams.ToList();
            return teams;
        }
        public Team GetTeamById(int id)
        {
            Team? team = _context.teams.Find(id);
             if(team == null)
            {
                throw new TeamException("Tapilmadi");
            }
             return team;
        }
        public void Update(int id,TeamUpdateVM teamUpdateVM)
        {
            Team? team = _context.teams.Find(id);
            if (team == null)
            {
                throw new TeamException("Tapilmadi");
            }
            team.Position= teamUpdateVM.Position;
            team.Name= teamUpdateVM.Name;
            if(team is not null)
            {
                string FileName = Path.GetFileNameWithoutExtension(teamUpdateVM.ImgFile.FileName);
                string extension = Path.GetExtension(teamUpdateVM.ImgFile.FileName);
                string FullName = FileName + Guid.NewGuid().ToString() + extension;
                team.ImgUrl = FullName;

                string UploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "UploadedImages");
                if (!Directory.Exists(UploadPath)) 
                { 
                    Directory.CreateDirectory(UploadPath);
                }
                UploadPath = Path.Combine(UploadPath, FullName);
                using FileStream stream = new FileStream(UploadPath, FileMode.Create);
                teamUpdateVM.ImgFile.CopyTo(stream);
            }
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Team? team = _context.teams.Find(id);
            if (team == null)
            {
                throw new TeamException("Tapilmadi");
            }
            _context.teams.Remove(team);
            _context.SaveChanges();
        }
    }
}
