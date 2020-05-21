using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using schedule.Entities;
using schedule.Enums;

namespace ScheduleInterface
{
    class MainWindowViewModel
    {
        public ObservableCollection<Class> Classes { get; set; }
        public bool IsDatabaseChecked { get; set; }
        public bool IsFileChecked { get; set; }
        public bool RadioButCheck { get; set; } = true;
        private ProgramMode programMode;
        public ICommand CreateCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public MainWindowViewModel()
        {
            CreateCommand = new DelegateCommand(Create);
            ShowCommand = new DelegateCommand(Show);
            Classes = new ObservableCollection<Class>();
        }
        private void SetProgramMode()
        {
            if(IsDatabaseChecked && IsFileChecked)
            {
                programMode = ProgramMode.Both;
            }
            else if(IsDatabaseChecked)
            {
                programMode = ProgramMode.Database;
            }
            else
            {
                programMode = ProgramMode.XML;
            }
        }
        public void Create(object o)
        {

        }
        public void Show(object o)
        {

        }
    }
}
