using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitapLad02Bai1
{
    class Info
    {
        private string name;
        private string truong;
        private string lop;
        private string loai;
        private string hocBong;

        public string Name { get => name; set => name = value; }
        public string Truong { get => truong; set => truong = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Loai { get => loai; set => loai = value; }
        public string HocBong { get => hocBong; set => hocBong = value; }

        public Info() { }
        public Info(string name, string truong, string lop, string loai, string hocBong)
        {
            this.HocBong = hocBong;
            this.Name = name;
            this.Lop = lop;
            this.Truong = truong;
            this.Loai = loai;
        }
    }
}
