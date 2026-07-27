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
 * The source repository can be found at https://github.com/xecrets/xecrets-texts please go there for more
 * information, suggestions and contributions. You may also visit https://www.axantum.com for more information about the
 * author, or submit support requests at https://www.axantum.com/support .
*/

#endregion Copyright and License

using System.Reflection;

using Xecrets.Localization;
using Xecrets.Texts.Properties;
using Xecrets.Texts.Translations;

namespace Xecrets.Texts;

/// <summary>
/// Localized texts for the application. The texts are exposed as public string properties or methods when parameters are required.
/// </summary>
/// <remarks>
/// <para>
/// Although all members are static, this class is intentionally non-static so that XAML bindings can access static
/// members through an instance property — typically <c>public Texts Texts { get; } = new();</c> on the view-model
/// base. Avalonia binding syntax such as <c>{Binding Texts.MenuAbout}</c> reaches the static members via that
/// instance without any per-call allocation.
/// </para>
/// <para>
/// When a localizable text resource is renamed, added or deleted, the corresponding property in this class must be
/// updated. Also, a new extraction of the resources must be done. Use 'extract-po-files.cmd' to extract the
/// resources to the .pot file and update the .po files.
/// The extraction is done with the tool POTools from https://github.com/xecrets/aspnetskeleton2 .
/// To update the translations in the .po files, use any suitable .po editor, e.g. Poedit or the online editor at
/// https://localise.biz etc. When the translations are updated, the .po files must be updated here and the project
/// rebuilt.
/// </para>
/// <para>
/// Useful resources for translation can be found at:
/// https://learn.microsoft.com/en-us/globalization/reference/microsoft-style-guides
/// https://learn.microsoft.com/en-us/globalization/reference/microsoft-language-resources
/// ChatGPT and DeepL (or whatever AI rules in the future) may be of assistance for translations.
/// </para>
/// </remarks>

// ReSharper disable UnusedMember.Global - this file is included in different projects, not all texts are used in each.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class Texts
{
    private static readonly ResourceFallbackLocalizer T = new ResourceFallbackLocalizer(
        new POStringLocalizerFactory(new POTranslationsProvider(Assembly.GetExecutingAssembly()))
            .Create(string.Empty, "Embedded .po resources"));

    #region Localized texts directly from resources
    public static string AboutTitle => T[nameof(Resources.ZzTitleAboutFormat)].FormatUi(InvariantResources.DisplayNameProgram);
    public static string BannerUnlicensedWarning => T[nameof(Resources.BannerUnlicensedWarning)];
    public static string BannerUnlicensedWarningMore => $"{T[nameof(Resources.BannerUnlicensedWarning)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ButtonAbout => T[nameof(Resources.MenuAbout)].MenuToLabelText();
    public static string ButtonCancel => T[nameof(Resources.ButtonCancel)];
    public static string ButtonClose => T[nameof(Resources.MenuClose)].MenuToLabelText();
    public static string ButtonCopy => T[nameof(Resources.ButtonCopy)];
    public static string ButtonCopyAll => T[nameof(Resources.ButtonCopyAll)];
    public static string ButtonCreate => T[nameof(Resources.ButtonCreate)];
    public static string ButtonCreateMobile => T[nameof(Resources.ButtonCreate)].MenuToLabelText();
    public static string ButtonDecrypt => T[nameof(Resources.MenuDecrypt)].MenuToLabelText();
    public static string ButtonEdit => T[nameof(Resources.MenuEdit)].MenuToLabelText();
    public static string ButtonEncrypt => T[nameof(Resources.MenuEncrypt)].MenuToLabelText();
    public static string ButtonExit => T[nameof(Resources.MenuExit)].MenuToLabelText();
    public static string ButtonFree => T[nameof(Resources.ButtonFree)];
    public static string ButtonGo => T[nameof(Resources.ButtonGo)];
    public static string ButtonHelp => T[nameof(Resources.MenuHelp)].MenuToLabelText();
    public static string ButtonLicense => T[nameof(Resources.ButtonLicense)];
    public static string ButtonNo => T[nameof(Resources.ButtonNo)];
    public static string ButtonOk => T[nameof(Resources.ButtonOk)];
    public static string ButtonOkMobile => T[nameof(Resources.ButtonOk)].MenuToLabelText();
    public static string ButtonOpen => T[nameof(Resources.MenuOpen)].MenuToLabelText();
    public static string ButtonPaste => T[nameof(Resources.MenuPaste)].MenuToLabelText();
    public static string ButtonPremium => T[nameof(Resources.ButtonPremium)];
    public static string ButtonReset => T[nameof(Resources.ButtonReset)];
    public static string ButtonRetry => T[nameof(Resources.ButtonRetry)];
    public static string ButtonSaveAs => T[nameof(Resources.ButtonSaveAs)];
    public static string ButtonWipe => T[nameof(Resources.MenuWipe)].MenuToLabelText();
    public static string ButtonYes => T[nameof(Resources.ButtonYes)];
    public static string CliToolApiVersionLabel => T[nameof(Resources.ZzLabelCliToolApiVersionFormat)].FormatUi(InvariantResources.DisplayNameCliTools);
    public static string CliToolInformationLabel => T[nameof(Resources.ZzLabelCliToolInformationFormat)].FormatUi(InvariantResources.DisplayNameCliTools);
    public static string CliToolPathLabel => T[nameof(Resources.ZzLabelCliToolPathFormat)].FormatUi(InvariantResources.DisplayNameCliTools);
    public static string CliVersionMismatchHelpId => InvariantResources.CliVersionMismatchHelpId;
    public static string CliVersionMismatchWarning => T[nameof(Resources.CliVersionMismatchWarning)];
    public static string CustomerPortalUrl => InvariantResources.CustomerPortalUrl.ToSite();
    public static string DecryptionPasswordsAboutFormat => T[nameof(Resources.DecryptionPasswordsAboutFormat)];
    public static string DialogInputValidationError => T[nameof(Resources.DialogInputValidationError)];
    public static string DialogInstructionEnterLicense => T[nameof(Resources.DialogInstructionEnterLicenseFormat)].FormatUi(InvariantResources.CustomerPortalUrl.ToSite(), InvariantResources.SiteUrl.ToSite());
    public static string DialogLabelAppSettingsDirectory => T[nameof(Resources.DialogLabelAppSettingsDirectory)];
    public static string DialogLabelCurrentDirectory => T[nameof(Resources.DialogLabelCurrentDirectory)];
    public static string DialogLabelRealStartFolder => T[nameof(Resources.DialogLabelRealStartFolder)];
    public static string DialogLabelStartCommand => T[nameof(Resources.DialogLabelStartCommand)];
    public static string DialogSavePasswordPermanently => T[nameof(Resources.DialogSavePasswordPermanently)];
    public static string DialogTextAddPassword => T[nameof(Resources.DialogTextAddPassword)];
    public static string DialogTextAllFiles => T[nameof(Resources.DialogTextAllFiles)];
    public static string DialogTextChangeEmail => T[nameof(Resources.MenuChangeEmail)].MenuToLabelText();
    public static string DialogTextChangePassword => T[nameof(Resources.MenuChangePassword)].MenuToLabelText();
    public static string DialogTextClearPasswords => T[nameof(Resources.MenuClearPasswords)].MenuToLabelText();
    public static string DialogTextClearRecent => T[nameof(Resources.MenuClearRecent)].MenuToLabelText();
    public static string DialogTextCliApiVersionError => T[nameof(Resources.DialogTextCliApiVersionError)];
    public static string DialogTextDowngradedVersionWarning => T[nameof(Resources.DialogTextDowngradedVersionWarning)];
    public static string DialogTextDropOrPasteTitle => T[nameof(Resources.DialogTextDropOrPasteTitle)];
    public static string DialogTextDropOrPasteToolTip => T[nameof(Resources.DialogTextDropOrPasteToolTip)];
    public static string DialogTextEncryptCopyFor => T[nameof(Resources.MenuEncryptCopyFor)].MenuToLabelText();
    public static string DialogTextEncryptDecryptText => T[nameof(Resources.MenuEncryptDecryptText)].MenuToLabelText();
    public static string DialogTextEncryptedFiles => T[nameof(Resources.DialogTextEncryptedFiles)];
    public static string DialogTextEnterLicense => T[nameof(Resources.DialogTextEnterLicense)];
    public static string DialogTextFileDoesNotExist => T[nameof(Resources.DialogTextFileDoesNotExist)];
    public static string DialogTextInsufficientRights => T[nameof(Resources.DialogTextInsufficientRights)];
    public static string DialogTextOpenFailed => T[nameof(Resources.DialogTextOpenFailed)];
    public static string DialogTextOrphanedDocumentsFiles => T[nameof(Resources.DialogTextOrphanedDocumentsFiles)];
    public static string DialogTextPasteOnlyTitle => T[nameof(Resources.DialogTextPasteOnlyTitle)];
    public static string DialogTextPasteOnlyToolTip => T[nameof(Resources.DialogTextPasteOnlyToolTip)];
    public static string DialogTextPrivateKeysImported => T[nameof(Resources.DialogTextPrivateKeysImported)];
    public static string DialogTextRelatedAccess => T[nameof(Resources.DialogTextRelatedAccess)].FormatUi(InvariantResources.XecretsHelpUrl.ToSite("#sandbox"));
    public static string DialogTextRemovableDriveFirstWarning => T[nameof(Resources.DialogTextRemovableDriveFirstWarning)];
    public static string DialogTextRemovableDriveUnplugWarning => T[nameof(Resources.DialogTextRemovableDriveUnplugWarning)];
    public static string DialogTextSuggestPassword => T[nameof(Resources.MenuSuggestPassword)].MenuToLabelText();
    public static string DialogTextSystemProtected => T[nameof(Resources.DialogTextSystemProtected)];
    public static string DialogTextTooLargeForLicense => T[nameof(Resources.DialogTextTooLargeForLicense)];
    public static string DialogTextUnknownPassword => T[nameof(Resources.DialogTextUnknownPassword)];
    public static string DialogTextWrongPasswordOpen => T[nameof(Resources.DialogTextWrongPasswordOpen)];
    public static string DialogTitleCombineShares => T[nameof(Resources.MenuCombineShares)].MenuToLabelText();
    public static string DialogTitleCreateShares => T[nameof(Resources.MenuCreateShares)].MenuToLabelText();
    public static string DialogTitleFetchLicense => T[nameof(Resources.DialogTitleFetchLicense)];
    public static string DialogTitleLoadShares => T[nameof(Resources.MenuLoadShares)].MenuToLabelText();
    public static string DialogTitleRandomRename => T[nameof(Resources.MenuRandomRename)].MenuToLabelText();
    public static string DialogTitleRemovableDrive => T[nameof(Resources.DialogTitleRemovableDrive)];
    public static string DialogTitleSelectDestinationFolder => T[nameof(Resources.DialogTitleSelectDestinationFolder)];
    public static string DialogTitleSelectFilesToDecrypt => T[nameof(Resources.DialogTitleSelectFilesToDecrypt)];
    public static string DialogTitleSelectFilesToEncrypt => T[nameof(Resources.DialogTitleSelectFilesToEncrypt)];
    public static string DialogTitleSelectFilesToReEncrypt => T[nameof(Resources.DialogTitleSelectFilesToReEncrypt)];
    public static string DialogTitleSelectFilesToWipe => T[nameof(Resources.DialogTitleSelectFilesToWipe)];
    public static string DialogTitleSelectFileToOpen => T[nameof(Resources.DialogTitleSelectFileToOpen)];
    public static string DialogTitleSelectFolder => T[nameof(Resources.DialogTitleSelectFolder)];
    public static string DialogValidationAlreadySignedIn => T[nameof(Resources.DialogValidationAlreadySignedIn)];
    public static string DialogValidationConfirmPassword => T[nameof(Resources.DialogValidationConfirmPassword)];
    public static string DialogValidationInvalidEmail => T[nameof(Resources.DialogValidationInvalidEmail)];
    public static string DialogValidationPasswordRequired => T[nameof(Resources.DialogValidationPasswordRequired)];
    public static string DialogValidationWrongPassword => T[nameof(Resources.DialogValidationWrongPassword)];
    public static string DialogYubiKeyChangeConfiguration => T[nameof(Resources.DialogYubiKeyChangeConfiguration)];
    public static string DialogYubiKeyDefaultChangeInfo => T[nameof(Resources.DialogYubiKeyDefaultChangeInfo)];
    public static string DialogYubiKeyDisable => T[nameof(Resources.DialogYubiKeyDisable)];
    public static string DialogYubiKeyEnable => T[nameof(Resources.DialogYubiKeyEnable)];
    public static string DialogYubiKeyEnabledFailed => T[nameof(Resources.DialogYubiKeyEnabledFailed)];
    public static string DialogYubiKeyEnterKeyTitle => T[nameof(Resources.DialogYubiKeyEnterKeyTitle)];
    public static string DialogYubiKeyEnterPinTitle => T[nameof(Resources.DialogYubiKeyEnterPinTitle)];
    public static string DialogYubiKeyLooking => T[nameof(Resources.DialogYubiKeyLooking)];
    public static string DialogYubiKeyManagementKeyDefault => T[nameof(Resources.DialogYubiKeyManagementKeyDefault)];
    public static string DialogYubiKeyMissingFeatures => T[nameof(Resources.DialogYubiKeyMissingFeatures)];
    public static string DialogYubiKeyNotConnected => T[nameof(Resources.DialogYubiKeyNotConnected)];
    public static string DialogYubiKeyNotInitialized => T[nameof(Resources.DialogYubiKeyNotInitialized)];
    public static string DialogYubiKeyNotSupported => T[nameof(Resources.DialogYubiKeyNotSupported)];
    public static string DialogYubiKeyOnlyTouch => T[nameof(Resources.DialogYubiKeyOnlyTouch)];
    public static string DialogYubiKeyOpenSecurity => T[nameof(Resources.DialogYubiKeyOpenSecurity)];
    public static string DialogYubiKeyPcscMissing => T[nameof(Resources.DialogYubiKeyPcscMissing)];
    public static string DialogYubiKeyPinDefault => T[nameof(Resources.DialogYubiKeyPinDefault)];
    public static string DialogYubiKeyPinRequired => T[nameof(Resources.DialogYubiKeyPinRequired)];
    public static string DialogYubiKeyPivSlotUsedFormat => T[nameof(Resources.DialogYubiKeyPivSlotUsedFormat)];
    public static string DialogYubiKeyPukDefault => T[nameof(Resources.DialogYubiKeyPukDefault)];
    public static string DialogYubiKeySelectMode => T[nameof(Resources.DialogYubiKeySelectMode)];
    public static string DialogYubiKeyServiceUnsupported => T[nameof(Resources.DialogYubiKeyServiceUnsupported)];
    public static string DialogYubiKeyTouchPrompt => T[nameof(Resources.DialogYubiKeyTouchPrompt)];
    public static string DisplayNameCliTools => InvariantResources.DisplayNameCliTools;
    public static string DisplayNameProgram => InvariantResources.DisplayNameProgram;
    public static string DisplayNameSdkApi => InvariantResources.DisplayNameSdkApi;
    public static string DontShowAgain => T[nameof(Resources.DontShowAgain)];
    public static string DownloadFreeTrialQuestion => T[nameof(Resources.DownloadFreeTrialQuestion)];
    public static string DropOrPasteTitle => Platform.IsLinux ? T[nameof(Resources.DialogTextPasteOnlyTitle)] : T[nameof(Resources.DialogTextDropOrPasteTitle)];
    public static string ErrorCombiningShares => T[nameof(Resources.ErrorCombiningShares)];
    public static string ErrorDuplicatesRemoved => T[nameof(Resources.ErrorDuplicatesRemoved)];
    public static string ExpiredCheckPurchaseWarning => T[nameof(Resources.ExpirationCheckPurchaseWarning)];
    public static string ExpiredCheckWarning => T[nameof(Resources.ExpirationCheckWarning)];
    public static string EzFeaturesUrl => InvariantResources.EzFeaturesUrl.ToSite();
    public static string FeatureNotFreeHideQuestion => T[nameof(Resources.FeatureNotFreeHideQuestion)];
    public static string FeatureNotFreeInformation => $"{T[nameof(Resources.FeatureNotFreeShortInformation)]}{Environment.NewLine + Environment.NewLine}{T[nameof(Resources.FeatureNotFreeInformation)].FormatUi(GetXecretsUrl)}{Environment.NewLine + Environment.NewLine}{T[nameof(Resources.FeatureNotFreeHideQuestion)]}";
    public static string FeatureNotFreeShortInformation => T[nameof(Resources.FeatureNotFreeShortInformation)];
    public static string FeatureNotFreeTitle => T[nameof(Resources.FeatureNotFreeTitle)].FormatUi(InvariantResources.DisplayNameProgram);
    public static string FileEncryptionUrl => InvariantResources.FileEncryptionUrl.ToSite();
    public static string FilesCanceledMessage => T[nameof(Resources.FilesCanceledMessage)];
    public static string FilesProcessedMessageFormat => T[nameof(Resources.FilesProcessedMessageFormat)];
    public static string GetLicenseTooltip => T[nameof(Resources.GetLicenseTooltip)];
    public static string GetLicenseUrlFormat => InvariantResources.GetLicenseUrlFormat.ToSite();
    public static string GetTrialUrlFormat => InvariantResources.GetTrialUrlFormat.ToSite();
    public static string GetXecretsUrl => InvariantResources.GetXecretsUrl.ToSite();
    public static string HeadingCreateNewUser => T[nameof(Resources.HeadingCreateNewUser)];
    public static string HeadingCreateUserFirstTimeSetup => T[nameof(Resources.HeadingCreateUserFirstTimeSetup)];
    public static string HeadingEmergencyReset => T[nameof(Resources.HeadingEmergencyReset)];
    public static string InvalidLicenseIgnored => T[nameof(Resources.InvalidLicenseIgnored)];
    public static string LabelDecryptionPasswordCountFormat => T[nameof(Resources.LabelDecryptionPasswordCountFormat)];
    public static string LabelLast4 => T[nameof(Resources.LabelLast4)];
    public static string LabelTheSecret => T[nameof(Resources.LabelTheSecret)];
    public static string LicensedBlurb => T[nameof(Resources.LicensedBlurb)];
    public static string LicensedExpiredBlurb => T[nameof(Resources.LicensedExpiredBlurb)];
    public static string LicenseHelpId => InvariantResources.LicenseHelpId;
    public static string LicenseNotValidForProductBlurb => T[nameof(Resources.LicenseNotValidForProductBlurb)];
    public static string MenuAbout => T[nameof(Resources.MenuAbout)];
    public static string MenuAddPassword => T[nameof(Resources.MenuAddPassword)];
    public static string MenuBuyNow => T[nameof(Resources.MenuBuyNow)];
    public static string MenuChangeEmail => T[nameof(Resources.MenuChangeEmail)];
    public static string MenuChangePassword => T[nameof(Resources.MenuChangePassword)];
    public static string MenuClearDontShowAgain => T[nameof(Resources.MenuClearDontShowAgain)];
    public static string MenuClearPasswords => T[nameof(Resources.MenuClearPasswords)];
    public static string MenuClearRecent => T[nameof(Resources.MenuClearRecent)];
    public static string MenuClipboardLicense => T[nameof(Resources.MenuClipboardLicense)];
    public static string MenuClose => T[nameof(Resources.MenuClose)];
    public static string MenuCombineShares => T[nameof(Resources.MenuCombineShares)];
    public static string MenuCreateShares => T[nameof(Resources.MenuCreateShares)];
    public static string MenuCreateUser => T[nameof(Resources.MenuCreateUser)];
    public static string MenuCustomerPortal => T[nameof(Resources.MenuCustomerPortal)];
    public static string MenuDebug => InvariantResources.MenuDebug;
    public static string MenuDecrypt => T[nameof(Resources.MenuDecrypt)];
    public static string MenuDecryptFolder => T[nameof(Resources.MenuDecryptFolder)];
    public static string MenuDownload => T[nameof(Resources.MenuDownload)];
    public static string MenuEdit => T[nameof(Resources.MenuEdit)];
    public static string MenuEncrypt => T[nameof(Resources.MenuEncrypt)];
    public static string MenuEncryptCopy => T[nameof(Resources.MenuEncryptCopy)];
    public static string MenuEncryptCopyFor => T[nameof(Resources.MenuEncryptCopyFor)];
    public static string MenuEncryptDecryptText => T[nameof(Resources.MenuEncryptDecryptText)];
    public static string MenuEncryptFolder => T[nameof(Resources.MenuEncryptFolder)];
    public static string MenuEnglish => InvariantResources.MenuEnglish;
    public static string MenuEnterLicense => T[nameof(Resources.MenuEnterLicense)];
    public static string MenuExit => T[nameof(Resources.MenuExit)];
    public static string MenuFile => T[nameof(Resources.MenuFile)];
    public static string MenuFrench => InvariantResources.MenuFrench;
    public static string MenuGerman => InvariantResources.MenuGerman;
    public static string MenuHelp => T[nameof(Resources.MenuHelp)];
    public static string MenuHelpSubmenu => T[nameof(Resources.MenuHelp)] + "...";
    public static string MenuHelpVideos => T[nameof(Resources.MenuHelpVideos)];
    public static string MenuInactivityExit => T[nameof(Resources.MenuInactivityExit)];
    public static string MenuInactivityNever => T[nameof(Resources.MenuInactivityNever)];
    public static string MenuInactivityTimeoutValueFormat => T[nameof(Resources.MenuInactivityTimeoutValueFormat)];
    public static string MenuItalian => InvariantResources.MenuItalian;
    public static string MenuLicense => T[nameof(Resources.MenuLicense)];
    public static string MenuLoadShares => T[nameof(Resources.MenuLoadShares)];
    public static string MenuOpen => T[nameof(Resources.MenuOpen)];
    public static string MenuOpenRecent => T[nameof(Resources.MenuOpenRecent)];
    public static string MenuPaste => T[nameof(Resources.MenuPaste)];
    public static string MenuPolish => InvariantResources.MenuPolish;
    public static string MenuPortugueseBrasil => InvariantResources.MenuPortugueseBrasil;
    public static string MenuPreferences => T[nameof(Resources.MenuPreferences)];
    public static string MenuRandomRename => T[nameof(Resources.MenuRandomRename)];
    public static string MenuReEncryptFiles => T[nameof(Resources.MenuReEncryptFiles)];
    public static string MenuReEncryptFolder => T[nameof(Resources.MenuReEncryptFolder)];
    public static string MenuShow => T[nameof(Resources.MenuShow)];
    public static string MenuSpanish => InvariantResources.MenuSpanish;
    public static string MenuSuggestPassword => T[nameof(Resources.MenuSuggestPassword)];
    public static string MenuSwedish => InvariantResources.MenuSwedish;
    public static string MenuTheme => T[nameof(Resources.MenuTheme)];
    public static string MenuTrialDownload => T[nameof(Resources.MenuTrialDownload)];
    public static string MenuUser => T[nameof(Resources.MenuUser)];
    public static string MenuWipe => T[nameof(Resources.MenuWipe)];
    public static string MenuYubiKey => T[nameof(Resources.MenuYubiKey)];
    public static string MessageFileFormatError => T[nameof(Resources.MessageFileFormatError)];
    public static string MessageNotEncrypted => T[nameof(Resources.MessageNotEncrypted)];
    public static string MessageTextBadLicenseString => T[nameof(Resources.MessageTextBadLicenseString)];
    public static string MessageTextConfirmManyFilesFormat => T[nameof(Resources.MessageTextConfirmManyFilesFormat)];
    public static string MessageTextConfirmPasteDirectory => T[nameof(Resources.MessageTextConfirmPasteDirectory)];
    public static string MessageTextConfirmWipe => T[nameof(Resources.MessageTextConfirmWipe)];
    public static string MessageTextForgotPassword => T[nameof(Resources.MessageTextForgotPassword)];
    public static string MessageZeroLength => T[nameof(Resources.MessageZeroLength)];
    public static string MixedFilesWarning => T[nameof(Resources.MixedFilesWarning)];
    public static string OpenFilesRemainMessage => T[nameof(Resources.OpenFilesRemainMessage)];
    public static string OperationCanceledFormat => T[nameof(Resources.OperationCanceledFormat)];
    public static string PasswordResetId => InvariantResources.PasswordResetId;
    public static string PlaceholderLoading => T[nameof(Resources.PlaceholderLoading)];
    public static string PrivateKeysAboutFormat => T[nameof(Resources.PrivateKeysAboutFormat)];
    public static string PromptEnterFirstShare => T[nameof(Resources.PromptEnterFirstShare)];
    public static string PromptEnterRemainingShares => T[nameof(Resources.PromptEnterRemainingShares)];
    public static string PromptRequiredShares => T[nameof(Resources.PromptRequiredShares)];
    public static string PromptTotalShares => T[nameof(Resources.PromptTotalShares)];
    public static string ReleaseNotesInformation => T[nameof(Resources.ReleaseNotesInformation)];
    public static string ReleaseNotesUrl => InvariantResources.ReleaseNotesUrl.ToSite();
    public static string RequestReviewQuestion => T[nameof(Resources.RequestReviewQuestion)];
    public static string RequestReviewUrl => InvariantResources.RequestReviewUrl.ToSite();
    public static string SdkApiVersionLabel => T[nameof(Resources.ZzLabelSdkApiVersionFormat)].FormatUi(InvariantResources.DisplayNameSdkApi);
    public static string SelectShareAny => T[nameof(Resources.SelectShareAny)];
    public static string SelectShareSignIn => T[nameof(Resources.SelectShareSignIn)];
    public static string ShamirsSecretSharing => InvariantResources.ShamirsSecretSharing;
    public static string SignInHeading => T[nameof(Resources.ZzHeadingSignInFormat)].FormatUi(InvariantResources.DisplayNameProgram);
    public static string SiteUrl => InvariantResources.SiteUrl.ToSite();
    public static string ThemeDark => T[nameof(Resources.ThemeDark)];
    public static string ThemeLight => T[nameof(Resources.ThemeLight)];
    public static string ThemeSystem => T[nameof(Resources.ThemeSystem)];
    public static string ToolTipAddPassword => T[nameof(Resources.ToolTipAddPassword)];
    public static string ToolTipAddPasswordMore => $"{T[nameof(Resources.ToolTipAddPassword)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ToolTipClearPasswords => T[nameof(Resources.ToolTipClearPasswords)];
    public static string ToolTipClearPasswordsMore => $"{T[nameof(Resources.ToolTipClearPasswords)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ToolTipClipboardLicense => T[nameof(Resources.MenuClipboardLicense)].MenuToLabelText();
    public static string ToolTipCombineShares => T[nameof(Resources.ToolTipCombineShares)];
    public static string ToolTipCombineSharesMore => $"{T[nameof(Resources.ToolTipCombineShares)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ToolTipCopySuggested => T[nameof(Resources.ToolTipCopySuggested)];
    public static string ToolTipCreateShares => T[nameof(Resources.ToolTipCreateShares)];
    public static string ToolTipCreateSharesMore => $"{T[nameof(Resources.ToolTipCreateShares)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ToolTipDecreaseScaleFactor => T[nameof(Resources.ToolTipDecreaseScaleFactor)];
    public static string ToolTipEmail => T[nameof(Resources.ToolTipEmail)];
    public static string ToolTipEmergencyReset => T[nameof(Resources.ToolTipEmergencyReset)];
    public static string ToolTipEncryptDecryptText => T[nameof(Resources.ToolTipEncryptDecryptText)];
    public static string ToolTipEncryptDecryptTextMore => $"{T[nameof(Resources.ToolTipEncryptDecryptText)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ToolTipGetLicense => T[nameof(Resources.ToolTipGetLicense)];
    public static string ToolTipGetLicenseMore => $"{T[nameof(Resources.ToolTipGetLicense)]} {T[nameof(Resources.ToolTipGetLicenseNoCard)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ToolTipGetLicenseNoCard => T[nameof(Resources.ToolTipGetLicenseNoCard)];
    public static string ToolTipHidePassword => T[nameof(Resources.ToolTipHidePassword)];
    public static string ToolTipHidePremium => T[nameof(Resources.ToolTipHidePremium)];
    public static string ToolTipIncreaseScaleFactor => T[nameof(Resources.ToolTipIncreaseScaleFactor)];
    public static string ToolTipMasterPassword => T[nameof(Resources.ToolTipMasterPassword)];
    public static string ToolTipShowPassword => T[nameof(Resources.ToolTipShowPassword)];
    public static string ToolTipShowPremium => T[nameof(Resources.ToolTipShowPremium)];
    public static string ToolTipSignIn => T[nameof(Resources.ToolTipSignIn)];
    public static string ToolTipSignInMore => $"{T[nameof(Resources.ToolTipSignIn)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ToolTipSuggestMasterPassword => T[nameof(Resources.ToolTipSuggestMasterPassword)];
    public static string ToolTipViewShares => T[nameof(Resources.ToolTipViewShares)];
    public static string ToolTipViewSharesMore => $"{T[nameof(Resources.ToolTipViewShares)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string ToolTipYubiKeySetup => T[nameof(Resources.ToolTipYubiKeySetup)];
    public static string ToolTipYubiKeySetupMore => $"{T[nameof(Resources.ToolTipYubiKeySetup)]} {T[nameof(Resources.TipMoreHelp)]}";
    public static string TurnDebugOff => InvariantResources.TurnDebugOff;
    public static string TurnDebugOn => InvariantResources.TurnDebugOn;
    public static string UnlicensedBlurb => T[nameof(Resources.UnlicensedBlurb)];
    public static string UpdateCheckInformation => T[nameof(Resources.UpdateCheckInformation)];
    public static string UpdateCheckTitle => T[nameof(Resources.UpdateCheckTitle)];
    public static string UrlDownloadXecretsFormat => InvariantResources.UrlDownloadXecretsFormat.ToSite();
    public static string WatermarkConfirmPassword => T[nameof(Resources.WatermarkConfirmPassword)];
    public static string WatermarkCurrentPassword => T[nameof(Resources.WatermarkCurrentPassword)];
    public static string WatermarkEmail => T[nameof(Resources.WatermarkEmail)];
    public static string WatermarkLast4 => T[nameof(Resources.WatermarkLast4)];
    public static string WatermarkNewPassword => T[nameof(Resources.WatermarkNewPassword)];
    public static string WatermarkPassword => T[nameof(Resources.WatermarkPassword)];
    public static string WatermarkPasswordSecret => T[nameof(Resources.WatermarkPasswordSecret)];
    public static string WatermarkPasswordShare => T[nameof(Resources.WatermarkPasswordShare)];
    public static string WatermarkPasteLicenseHere => T[nameof(Resources.WatermarkEnterLicenseHere)];
    public static string YouTubeVideosUrl => InvariantResources.YouTubeVideosUrl.ToSite();
    public static string ZeroLengthWarning => T[nameof(Resources.ZeroLengthWarning)];
    #endregion Localized texts directly from resources

    #region Localized texts with additional formatting arguments
    /// <summary>
    /// Appends the standard confirmation question to a message.
    /// </summary>
    /// <param name="m">The primary message text to confirm.</param>
    public static string Confirmation(string m) => $"{m} {T[nameof(Resources.ConfirmationQuestion)]}";

    /// <summary>
    /// The about-text for the decryption passwords panel, parameterized on the password count.
    /// </summary>
    /// <param name="n">The number of decryption passwords currently loaded.</param>
    public static string DecryptionPasswordsAbout(int n) => T[nameof(Resources.DecryptionPasswordsAboutFormat)].FormatUi(n);

    /// <summary>
    /// The information text shown when a license is expiring soon.
    /// </summary>
    /// <param name="expiresLocal">The expiry date and time, already formatted in the local timezone.</param>
    public static string DialogTextExpiresSoonInfo(string expiresLocal) => T[nameof(Resources.DialogTextExpiresSoonInfoFormat)].FormatUi(expiresLocal);

    /// <summary>
    /// The message shown when the YubiKey CCID redistributable is missing, with a link to download it.
    /// </summary>
    /// <param name="link">The URL or display text of the download link.</param>
    public static string DialogYubiKeyRedistributableMissing(string link) => T[nameof(Resources.DialogYubiKeyRedistributableMissing)].FormatUi(link);

    /// <summary>
    /// The copy-key tooltip text, parameterized on the platform-specific copy key name since
    /// Xecrets.Texts has no dependency on the platform abstractions in Xecrets.Ez.Models.
    /// </summary>
    /// <param name="copyKeyName">The platform-specific name of the copy key, e.g. "Ctrl" or "Option".</param>
    public static string DropOrPasteToolTip(string copyKeyName) =>
        (Platform.IsLinux ? T[nameof(Resources.DialogTextPasteOnlyToolTip)] : T[nameof(Resources.DialogTextDropOrPasteToolTip)]).FormatUi(copyKeyName);

    /// <summary>
    /// The title of the application, parameterized on the version and signed-in email since Xecrets.Texts
    /// has no dependency on the DI-resolved IEzVersion/IUsers abstractions in Xecrets.Ez.Models.
    /// </summary>
    /// <param name="version">The application version.</param>
    /// <param name="isSignedIn">True if a user is currently signed in.</param>
    /// <param name="email">The signed-in user's email, ignored if <paramref name="isSignedIn"/> is false.</param>
    public static string EzTitle(Version version, bool isSignedIn, string email) =>
        T[nameof(Resources.ZzTitleProgramVersionNameFormat)].FormatUi(version, InvariantResources.DisplayNameProgram, isSignedIn ? email : string.Empty).Trim();

    /// <summary>
    /// The command bar label showing the number of currently open files.
    /// </summary>
    /// <param name="n">The number of open files; selects the appropriate plural form.</param>
    public static string FilesOpen(int n) => T[nameof(Resources.ZzCommandBarContentFilesOpenFormat)].PluralFormatUi(n);

    /// <summary>
    /// The status message shown after a batch file operation completes.
    /// </summary>
    /// <param name="n">The number of files processed; selects the appropriate plural form.</param>
    public static string FilesProcessedMessage(int n) => T[nameof(Resources.FilesProcessedMessageFormat)].PluralFormatUi(n);


    /// <summary>
    /// The label for the decryption password clear button, showing the current count.
    /// </summary>
    /// <param name="n">The number of loaded decryption passwords; selects the appropriate plural form.</param>
    public static string LabelClearPasswords(int n) => T[nameof(Resources.LabelDecryptionPasswordCountFormat)].PluralFormatUi(n);

    /// <summary>
    /// The confirmation message shown before acting on a large number of files.
    /// </summary>
    /// <param name="n">The number of files to be processed.</param>
    public static string MessageTextConfirmManyFiles(int n) => T[nameof(Resources.MessageTextConfirmManyFilesFormat)].FormatUi(n);

    /// <summary>
    /// The about-text for the private keys panel, parameterized on the counts of user-specific and total keys.
    /// </summary>
    /// <param name="u">The number of private keys for the current user.</param>
    /// <param name="t">The total number of private keys loaded.</param>
    public static string PrivateKeysAbout(int u, int t) => T[nameof(Resources.PrivateKeysAboutFormat)].FormatUi(u, t);

    /// <summary>
    /// The about-dialog splash text, parameterized on the version, runtime, build time and license blurb,
    /// since Xecrets.Texts has no dependency on the DI-resolved abstractions in Xecrets.Ez.Models, and since
    /// the splash file resource itself stays in Xecrets.Ez.Models.
    /// </summary>
    /// <param name="splashTemplate">The splash text template, with {version}/{runtime}/{buildutc}/{blurb} placeholders.</param>
    /// <param name="version">The application version.</param>
    /// <param name="runtime">The runtime description.</param>
    /// <param name="buildUtcTextLocal">The build time, already converted to local time and formatted as text.</param>
    /// <param name="isInDesignMode">True if running in the Avalonia designer, in which case the license blurb is not shown.</param>
    /// <param name="blurb">The license blurb, ignored if <paramref name="isInDesignMode"/> is true.</param>
    public static string Splash(string splashTemplate, Version version, string runtime, string buildUtcTextLocal, bool isInDesignMode, string blurb) =>
        splashTemplate
            .Replace("{version}", version.ToString())
            .Replace("{runtime}", runtime)
            .Replace("{buildutc}", buildUtcTextLocal)
            .Replace("{blurb}", isInDesignMode ? "License info not shown in design mode." : blurb);

    /// <summary>
    /// The description for the share-viewer panel, showing the number of shares currently loaded.
    /// </summary>
    /// <param name="n">The number of shares loaded; selects the appropriate plural form.</param>
    public static string ViewSharesDescriptionFormat(int n) => T[nameof(Resources.ViewSharesDescriptionFormat)].FormatUi(n);

    /// <summary>
    /// The help site URL for Xecrets Ez, optionally with a named fragment anchor.
    /// </summary>
    /// <param name="fragment">An optional URL fragment, e.g. <c>"#sandbox"</c>. Defaults to an empty string.</param>
    public static string XecretsHelpUrl(string fragment = "") => InvariantResources.XecretsHelpUrl.ToSite(fragment);
    #endregion Localized texts with additional formatting
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
