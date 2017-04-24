using UnityEngine;
using System.Collections;

namespace AdvUIM{
	public class uimSplash: UISingleton<uimSplash>  {
		private Animator _animator; 

		public enum Status {
			show=0, hide=1
		};

		public Status currentStatus;

		protected uimSplash () {} // guarantee this will be always a singleton only - can't use the constructor!

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
				if(AdvUIM.uimSplash.InstanceManager.IsShown!=true){
					AdvUIM.uimSplash.InstanceManager.IsShown = true;
				}

				break;
			case Status.hide:
				//print (currentStatus);
				if (AdvUIM.uimSplash.InstanceManager.IsShown == true) {
					AdvUIM.uimSplash.InstanceManager.IsShown = false;
				}
				break;
			default:
				break;
			}

		}


		public void AutoHideSplash(float sec){
			StartCoroutine(TimeToHide(sec));
		}

		public IEnumerator TimeToHide(float sec){
			yield return new WaitForSeconds (sec);
			AdvUIM.uimSplash.InstanceManager.IsShown = false;

		}



		void Awake(){
			_animator = GetComponent<Animator>();
			//SetStatus (currentStatus);



		}
	}
}
