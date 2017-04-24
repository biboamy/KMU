using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace AdvUIM{
	public class uimMenu: UISingleton<uimMenu>  {

		private Animator _animator; 
		private bool timerEnabled;

		public enum Status {
			show=0, hide=1
		};


		public Status currentStatus;



		protected uimMenu () {} // guarantee this will be always a singleton only - can't use the constructor!


		void Awake(){
			_animator = GetComponent<Animator>();
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
				if(AdvUIM.uimMenu.InstanceManager.IsShown!=true){
					AdvUIM.uimMenu.InstanceManager.IsShown = true;
				}

				break;
			case Status.hide:
				//print (currentStatus);
				if (AdvUIM.uimMenu.InstanceManager.IsShown == true) {
					AdvUIM.uimMenu.InstanceManager.IsShown = false;
				}
				break;
			default:
				break;
			}

		}






	}
}
