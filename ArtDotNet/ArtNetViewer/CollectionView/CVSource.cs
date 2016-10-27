using System;
namespace ArtNetViewer
{
	public class CVSource : INSCollectionViewSource
	{
		string[] data = { "one", "two", "three", "four" };

		public override int GetItemsCount(UICollectionView collectionView, int section)
		{
			return data.Length;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var textCell = (TextCell)collectionView.DequeueReusableCell(TextCell.CellId, indexPath);

			textCell.Text = data[indexPath.Row];

			return textCell;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			Console.WriteLine("Row {0} selected", indexPath.Row);
		}

		public override bool ShouldSelectItem(UICollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}
	}
}
