// SPDX-FileCopyrightText: 2022 mirrorcult <lunarautomaton6@gmail.com>
// SPDX-FileCopyrightText: 2023 Leon Friedrich <60421075+ElectroJr@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 moonheart08 <moonheart08@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Piras314 <p1r4s@proton.me>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Verbs;
using Robust.Client.UserInterface.Controls;
using Robust.Client.Utility;

namespace Content.Client.Examine;

/// <summary>
///     Buttons that show up in the examine tooltip to specify more detailed
///     ways to examine an item.
/// </summary>
public sealed class ExamineButton : ContainerButton
{
    public const string StyleClassExamineButton = "examine-button";

    public const int ElementHeight = 32;
    public const int ElementWidth = 32;

    private const int Thickness = 4;

    public TextureRect Icon;

    public ExamineVerb Verb;

    public ExamineButton(ExamineVerb verb)
    {
        Margin = new Thickness(Thickness, Thickness, Thickness, Thickness);

        SetOnlyStyleClass(StyleClassExamineButton);

        Verb = verb;

        if (verb.Disabled)
        {
            Disabled = true;
        }

        ToolTip = verb.Message ?? verb.Text;

        Icon = new TextureRect
        {
            SetWidth = ElementWidth,
            SetHeight = ElementHeight
        };

        if (verb.Icon != null)
        {
            Icon.Texture = verb.Icon.Frame0();
            Icon.Stretch = TextureRect.StretchMode.KeepAspectCentered;

            AddChild(Icon);
        }
    }
}