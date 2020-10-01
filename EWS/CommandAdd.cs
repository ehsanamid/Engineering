using DCS.Draw;
using DCS.Tools;
namespace DCS
{
	/// <summary>
	/// Add new object command
	/// </summary>
	internal class CommandAdd : Command
	{
		private DrawObject drawObject;

		// Create this command with DrawObject instance added to the list
		public CommandAdd(DrawObject drawObject) : base()
		{
			// Keep copy of added object
			this.drawObject = drawObject.Clone();
		}

		/// <summary>
		/// Undo last Add command
		/// </summary>
		/// <param name="list">Layers collection</param>
        public override void Undo(GraphicsList list)
		{
            list.DeleteLastAddedObject();
		}

		/// <summary>
		/// Redo last Add command
		/// </summary>
		/// <param name="list">Layers collection</param>
        public override void Redo(GraphicsList list)
		{
           // list.UnselectAll();
            list.Add(drawObject);
		}
	}
}