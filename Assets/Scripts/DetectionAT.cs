using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DetectionAT : ActionTask {

		public float searchRadius;

		public LayerMask theif;

		BBParameter <Transform> DetectTarget;




		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			
			
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			//EndAction(true);

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			Transform bestTarget = null;
			float closestDistance = searchRadius; 

			Collider[] theifColliders = Physics.OverlapSphere(agent.transform.position, searchRadius, theif);

			if(theifColliders.Length == 0)
			{
				return;
			}

			foreach (Collider theifCollider in theifColliders)
			{
				float currentDistance = Vector3.Distance(agent.transform.position, theifCollider.transform.position);
				if(currentDistance < closestDistance)
				{
					bestTarget = theifCollider.transform;
					closestDistance = currentDistance;

				}

            }

			if (bestTarget != null)
			{
                Debug.DrawLine(agent.transform.position, bestTarget.position, Color.red);
				EndAction(true);
            }
			else 
			{

				EndAction(false);

			}
		

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}