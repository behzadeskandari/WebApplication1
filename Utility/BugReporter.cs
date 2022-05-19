﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UtilitySpace
{
    public static class BugReporter
    {
        public const string Template = "<div style='text-align:left;direction:ltr;padding:5px;font-family:Tahoma;'><table><tr><td>Title: </td><td>[Title]</td></tr><tr><td>Date: </td><td>[Date]</td></tr><tr><td>Message: </td><td>[Message]</td></tr><tr><td>Inner Exception: </td><td>[ErrorMsgInerEx]</td></tr><tr><td>Help Link: </td><td>[HelpLink]</td></tr><tr><td>UserName: </td><td>[UserName]</td></tr><tr><td>Route: </td><td>[Controler]/[Action]</td></tr></table></div>";

    }

}
