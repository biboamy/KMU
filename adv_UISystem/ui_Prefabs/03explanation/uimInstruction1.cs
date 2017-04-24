using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using cqplayart.amy.RWControl;
using Vuforia;

namespace AdvUIM{
	public class uimInstruction1: UISingleton<uimInstruction1>  {

		private Animator _animator; 
		private bool timerEnabled;
		static myRWControl myControl;
		static private string filename = "testFirst";

		public enum Status {
			show=0, hide=1
		};


		public Status currentStatus;



		protected uimInstruction1 () {} // guarantee this will be always a singleton only - can't use the constructor!


		void Awake(){
			_animator = GetComponent<Animator>();
			myControl = new RWInterfaceBehavior();
		}

		public void testFirst()
		{
			if (myControl.readfile(filename) == null)
			{
				IsShown = true;
				myControl.writefile(filename, "1");
			}
			else
			{
				showFinder();
			}
		}

		private void showFinder()
		{
			IsShown = false;
			AdvUIM.uimFinder.InstanceManager.IsShown = true;
			ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
			foreach (DataSet data in tracker.GetDataSets())
				tracker.ActivateDataSet(data);

			if(GameObject.Find("05AR") != null)
				GameObject.Find("05AR").SetActive(false);
		}

		public void iknowClick()
		{
			showFinder();
		}

		public bool IsShown{
			get {return _animator.GetBool ("IsShown"); }
			set {  _animator.SetBool ("IsShown", value);}
		}

		public void SetStatus(Status status){
			//AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

			currentStatus = status;
			switch (currentStatus) {
			case Status.show:
				//print (currentStatus);
				if(AdvUIM.uimInstruction1.InstanceManager.IsShown!=true){
					AdvUIM.uimInstruction1.InstanceManager.IsShown = true;
				}

				break;
			case Status.hide:
				//print (currentStatus);
				if (AdvUIM.uimInstruction1.InstanceManager.IsShown == true) {
					AdvUIM.uimInstruction1.InstanceManager.IsShown = false;
				}
				break;
			default:
				break;
			}

		}






	}
}
