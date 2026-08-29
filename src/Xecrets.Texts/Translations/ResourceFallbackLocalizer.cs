#region Copyright and License

/*
 * Xecrets Texts - Copyright © 2022-2026, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Texts
 *
 * Xecrets Texts is free software: you can redistribute it and/or modify it under the terms of the GNU General
 * Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any
 * later version.
 *
 * Xecrets Texts is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with Xecrets Texts.  If not, see
 * <https://www.gnu.org/licenses/>.
 *
 * The source repository can be found at https://github.com/xecrets/xecrets-common please go there for more
 * information, suggestions and contributions. You may also visit https://www.axantum.com for more information about the
 * author, or submit support requests at https://www.axantum.com/support .
*/

#endregion Copyright and License


using System.Globalization;

using Microsoft.Extensions.Localization;

using Xecrets.Texts.Properties;

namespace Xecrets.Texts.Translations;

internal class ResourceFallbackLocalizer(IStringLocalizer localizer) : IStringLocalizer
{
    public LocalizedString this[string name]
    {
        get
        {
            LocalizedString ls = localizer[name];
            if (ls.ResourceNotFound)
            {
                string resourceString = Resources.ResourceManager.GetString(name) ?? name;
                ls = new LocalizedString(name, resourceString, true, nameof(Resources));
            }
            return ls;
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            LocalizedString ls = this[name];
            return new LocalizedString(ls.Name, string.Format(CultureInfo.CurrentCulture, ls.Value, arguments), ls.ResourceNotFound,
                ls.ResourceNotFound ? nameof(Resources) : ls.SearchedLocation);
        }
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) =>
        localizer.GetAllStrings(includeParentCultures);
}
