namespace JBleiloes.data.Utilizadores
{
    public class SessionUser
    {
        private static Utilizador? sessionUser = null;

        public SessionUser()
        {

        }

        public static void setSessionUser(Utilizador sessionUser)
        {
            SessionUser.sessionUser = sessionUser;
        }

        public static Utilizador? getSessionUser()
        {
            if (sessionUser == null) { return  null; }
            return sessionUser;
        }
    }
}
