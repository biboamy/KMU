using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace AdvUIM{
	public class uimNaviBar: UISingleton<uimNaviBar>  {

		private Animator _animator; 
		private bool timerEnabled;

		[SerializeField]
		private GameObject naviBarTitle;
		private Image currentTitleImage;

		public Sprite titleImgDefault;
		public List<Sprite> titleImg = new List<Sprite>();


		public enum Status {
			show=0, hide=1
		};


		public Status currentStatus;



		protected uimNaviBar () {} // guarantee this will be always a singleton only - can't use the constructor!


		void Awake(){
			_animator = GetComponent<Animator>();
			currentTitleImage = naviBarTitle.GetComponent<Image> ();
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
				if(AdvUIM.uimNaviBar.InstanceManager.IsShown!=true){
					AdvUIM.uimNaviBar.InstanceManager.IsShown = true;
				}

				break;
			case Status.hide:
				//print (currentStatus);
				if (AdvUIM.uimNaviBar.InstanceManager.IsShown == true) {
					AdvUIM.uimNaviBar.InstanceManager.IsShown = false;
				}
				break;
			default:
				break;
			}

		}

		public void ChangeNaviBarTitle(int setNo){
			currentTitleImage.sprite = titleImg[setNo];
		
		}




	}
}
