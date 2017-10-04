using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu2Des
{
    class DoublonException : Exception
    {
        public DoublonException(Classement highscore): base(highscore.ToString()) { }

        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

    }
}
