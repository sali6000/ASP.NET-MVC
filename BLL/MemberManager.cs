using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MemberManager
    {
        public static MemberEntity GetById(int id) { return new MemberProvider().SelectMember(id); }
        public static List<MemberEntity> GetList() { return new MemberProvider().SelectMembers(); }
        public static int Add(MemberEntity member) { return new MemberProvider().AddMember(member); }
        public static void Update(MemberEntity member) { new MemberProvider().UpdateMember(member); }
        public static void Delete(int id) { new MemberProvider().DeleteMember(id); }
        public static bool UsernameExist(MemberEntity member) { return new MemberProvider().UsernameExist(member); }
        public static bool EmailExist(MemberEntity member) { return new MemberProvider().EmailExist(member); }
    }
}
