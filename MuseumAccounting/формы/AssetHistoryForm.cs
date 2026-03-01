using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MuseumAccounting
{
    public partial class AssetHistoryForm : Form
    {
        private int _assetId;

        public AssetHistoryForm(int assetId)
        {
            InitializeComponent();
            _assetId = assetId;
        }

        private void AssetHistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    var movements = context.AssetMovements
                        .Where(m => m.FixedAssetId == _assetId)
                        .Include(m => m.OldLocation)
                        .Include(m => m.NewLocation)
                        .OrderByDescending(m => m.MovementDate)
                        .Select(m => new
                        {
                            MovementDate = m.MovementDate,
                            OldLocationName = m.OldLocation != null ? m.OldLocation.Name : "(вне учёта)",
                            NewLocationName = m.NewLocation.Name,
                            m.Reason
                        })
                        .ToList();

                    dgvHistory.DataSource = movements;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки истории: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}