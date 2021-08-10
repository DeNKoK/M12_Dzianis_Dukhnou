namespace M12_Dzianis_Dukhnou.Frame
{
    public static class UrlFactory
    {
        public static string GetUrl(ResourseType resourse)
        {
            string url = null;

            switch (resourse)
            {
                case ResourseType.Users:
                    {
                        url = Configuration.Url + "/users";
                        break;
                    }
                case ResourseType.Posts:
                    {
                        url = Configuration.Url + "/posts";
                        break;
                    }
                case ResourseType.Comments:
                    {
                        url = Configuration.Url + "/comments";
                        break;
                    }
                case ResourseType.Albums:
                    {
                        url = Configuration.Url + "/albums";
                        break;
                    }
                case ResourseType.Photos:
                    {
                        url = Configuration.Url + "/photos";
                        break;
                    }
                case ResourseType.Todos:
                    {
                        url = Configuration.Url + "/todos";
                        break;
                    }
            }

            return url;
        }
    }
}
