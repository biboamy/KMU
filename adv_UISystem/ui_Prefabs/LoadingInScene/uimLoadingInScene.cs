using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace AdvUIM{
	public class uimLoadingInScene: UISingleton<uimLoadingInScene>  {
		
		private Animator _animator; 
		private bool timerEnabled;

		public enum Status {
			show=0, hide=1
		};


		public Status currentStatus;
	

		public GameObject progressBar;

		protected uimLoadingInScene () {} // guarantee this will be always a singleton only - can't use the constructor!



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
				if(AdvUIM.uimLoadingInScene.InstanceManager.IsShown!=true){
					AdvUIM.uimLoadingInScene.InstanceManager.IsShown = true;
				}

				break;
			case Status.hide:
				//print (currentStatus);
				if (AdvUIM.uimLoadingInScene.InstanceManager.IsShown == true) {
					AdvUIM.uimLoadingInScene.InstanceManager.IsShown = false;
				}
				break;
			default:
				break;
			}

		}

		public void UpdateProgress(double progressValue){
			progressBar.GetComponent<Image> ().fillAmount = (float)progressValue;
		}

	
		public void FakeUpdateProgress(float sec){
			timerEnabled = true;
			AdvUIM.uimLoadingInScene.InstanceManager.progress (0);
			AutoHide((float)sec);
		}

	
		void AutoHide(float sec){
			AdvUIM.uimLoadingInScene.InstanceManager.IsShown = true;
			StartCoroutine(TimeToHide(sec));
		}

		IEnumerator TimeToHide(float sec){
			float updateInterval = 0.05f; 
			float currentProgress = progressBar.GetComponent<Image> ().fillAmount;
			float progressValue = updateInterval/sec;

			if (timerEnabled && currentProgress < 1) {
				yield return new WaitForSeconds (updateInterval);
				progressBar.GetComponent<Image> ().fillAmount += progressValue;
				AutoHide (sec);
			} else {
				timerEnabled = false;
				AdvUIM.uimLoadingInScene.InstanceManager.IsShown = false;
			}

		}


		void Awake(){
			_animator = GetComponent<Animator>();
			//SetStatus (currentStatus);



		}

		void Start(){


		}
	}
}
