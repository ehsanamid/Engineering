using DCS.Draw;
using DCS.Tools;
using System.Collections.Generic;

namespace DCS
{
	/// <summary>
	/// Changing state of existing objects:
	/// move, resize, change properties.
	/// </summary>
	internal class CommandChangeState : Command
	{
		// Selected object(s) before operation
		private List<DrawObject> listBefore;

		// Selected object(s) after operation
		private List<DrawObject> listAfter;

		// Track the active Layer where the change took place
		//private int activeLayer;

		// Create this command BEFORE operation.
        public CommandChangeState(GraphicsList graphicsList)
		{
			// Keep objects state before operation.
            FillList(graphicsList, ref listBefore);
		}

		// Call this function AFTER operation.
        public void NewState(GraphicsList graphicsList)
		{
			// Keep objects state after operation.
            FillList(graphicsList, ref listAfter);
		}

        public override void Undo(GraphicsList list)
		{
			// Replace all objects in the list with objects from listBefore
            ReplaceObjects(list, listBefore);
		}

        public override void Redo(GraphicsList list)
		{
			// Replace all objects in the list with objects from listAfter
            ReplaceObjects(list, listAfter);
		}

		// Replace objects in graphicsList with objects from list
		private void ReplaceObjects(GraphicsList graphicsList, List<DrawObject> list)
		{
			for (int i = 0; i < graphicsList.Count; i++)
			{
				DrawObject replacement = null;

				foreach (DrawObject o in list)
				{
					if (o.ID == graphicsList[i].ID)
					{
						replacement = o;
						break;
					}
				}

				if (replacement != null)
				{
					graphicsList.Replace(i, replacement);
				}
			}
		}

		// Fill list from selection
		private void FillList(GraphicsList graphicsList, ref List<DrawObject> listToFill)
		{
			listToFill = new List<DrawObject>();

			foreach (DrawObject o in graphicsList.Selection)
			{
				listToFill.Add(o.Clone());
			}
		}
	}
}