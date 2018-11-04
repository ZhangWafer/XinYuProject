namespace XinYu.Framework.Membership.Model
{
    public class ModuleInfo : ModelBase
    {
        public const int CONST_EMPTY_ID = 0;

        int id;
        int rootID = CONST_EMPTY_ID;
        int parentID = CONST_EMPTY_ID;

        string name;
        string url;
        string icon;

        bool isMenu;
        bool isFloder;
        bool isPopedom;




        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int RootID
        {
            get { return this.rootID; }
            set { this.rootID = value; }
        }

        public int ParentID
        {
            get { return this.parentID; }
            set { this.parentID = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Url
        {
            get { return this.url; }
            set { this.url = value; }
        }

        public string Icon
        {
            get { return this.icon; }
            set { this.icon = value; }
        }

        public bool IsMenu
        {
            get { return this.isMenu; }
            set { this.isMenu = value; }
        }

        public bool IsFloder
        {
            get { return this.isFloder; }
            set { this.isFloder = value; }
        }

        public bool IsPopedom
        {
            get { return this.isPopedom; }
            set { this.isPopedom = value; }
        }

    }
}
