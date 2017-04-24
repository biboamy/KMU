/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

		#endregion // PUBLIC_METHODS



		#region PRIVATE_METHODS


		private void OnTrackingFound()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}

			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

			//hide all ui objects
			/*for (int i = 0; i < 4; i++)
			{
				foreach (GameObject showOj in GameObject.FindObjectsOfType(typeof(GameObject)))
				{
					if (showOj.name == "trackoj" + (i + 1).ToString())
						showOj.SetActive(false);
				}
			}

            
			string[] Oj = mTrackableBehaviour.TrackableName.Split('k');*/
        }


        private void OnTrackingLost()
        {
            /*Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }*/

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

			/*bool status = GameObject.Find("statusControl").GetComponent<statusControl>().status;

			if (status == true)
			{
				//show ui object
				string[] Oj = mTrackableBehaviour.TrackableName.Split('k');
				foreach (GameObject showOj in GameObject.FindObjectsOfType(typeof(GameObject)))
				{
					if(showOj.name == "trackoj" + Oj[1])
						showOj.SetActive(true);
					if (showOj.name == "flooroj")
						showOj.SetActive(true);
				}
			}*/
        }

        #endregion // PRIVATE_METHODS
    }
}
