using System;
using AARPG.Core.Mechanics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace AARPG.API.UI;
public class PerkSquare : UIElement
{
	public Perk AssociatedPerk { get; private set; }
	private static Texture2D _whitePixelTexture;
	private readonly UIText _tooltip = new("");
	public readonly UIText _perkName;

	public PerkSquare(Perk associatedPerk)
	{
		AssociatedPerk = associatedPerk;
		Width.Set(50f, 0f); 
		Height.Set(50f, 0f);
		if (_whitePixelTexture == null)
		{
			_whitePixelTexture = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
			_whitePixelTexture.SetData(new[] { Color.White });
		}
		_perkName = new UIText(associatedPerk.name, 0.9f);
	}

	protected override void DrawSelf(SpriteBatch spriteBatch) {
		var color = AssociatedPerk.IsEnabled(AssociatedPerk.name) ? Color.Aqua : Color.Red; //Aqua when enabled, red when not
		spriteBatch.Draw(_whitePixelTexture, GetInnerDimensions().ToRectangle(), color);
		if (!string.IsNullOrWhiteSpace(_tooltip.Text)) {
			_tooltip.Left.Set(Main.mouseX, 0f);
			_tooltip.Top.Set(Main.mouseY + 20, 0f);
			_tooltip.Recalculate();
			_tooltip.Draw(spriteBatch);
		}
		if (!string.IsNullOrWhiteSpace(_perkName.Text)) {
			_perkName.Left.Set(Parent.MarginLeft, 0f);
			_perkName.Top.Set(Parent.MarginTop + (GetInnerDimensions().Y - 5), 0f);
			_perkName.Recalculate();
			_perkName.Draw(spriteBatch);
		}
	}
	
	public override void MouseOver(UIMouseEvent evt)
	{
		base.MouseOver(evt);

		// We set the text we want to display here
		var hoverText = $"{AssociatedPerk.name}";

		// Add the hover text
		_tooltip.SetText(hoverText);
	}
	public override void MouseOut(UIMouseEvent evt)
	{
		base.MouseOut(evt);
		// Add the hover text
		_tooltip.SetText("");
	}

	public override void LeftClick(UIMouseEvent evt)
	{
		AssociatedPerk.Enable(AssociatedPerk);
		Console.Write("Left Clicked");
	}

	public override void RightClick(UIMouseEvent evt)
	{
		AssociatedPerk.Disable(AssociatedPerk);
	}
}
