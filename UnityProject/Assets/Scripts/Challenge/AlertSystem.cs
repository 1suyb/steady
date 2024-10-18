using UnityEngine;

public class AlertSystem : MonoBehaviour
{
    // fov가 45라면 45도 각도안에 있는 aesteriod를 인식할 수 있음.
    [SerializeField] private float fov = 45f;
    // radius가 10이라면 반지름 10 범위에서 aesteriod들을 인식할 수 있음.
    [SerializeField] private float radius = 10f;
    private float alertThreshold;

    private Animator animator;
    private static readonly int blinking = Animator.StringToHash("isBlinking");

    private void Start()
    {
        animator = GetComponent<Animator>();
		// FOV를 라디안으로 변환하고 코사인 값을 계산
		alertThreshold = Mathf.Cos(fov * Mathf.Deg2Rad);
    }

    private void Update()
    {
        CheckAlert();
    }

    private void CheckAlert()
    {
        // 주변 반경의 소행성들을 확인하고 이를 감지하여 Alert를 발생시킴(isBlinking -> true)
        Collider2D cols = Physics2D.OverlapCircle(transform.position, radius,1<<6);

        if(cols != null )
        {
            Debug.Log(cols.gameObject.name);
			Vector3 dirvec = (cols.transform.position - this.transform.position).normalized;
			float dot = Mathf.Abs(Vector3.Dot(dirvec, this.transform.up));
			if (dot > alertThreshold)
			{
				this.animator.SetBool(blinking, true);
			}
			else { this.animator.SetBool(blinking, false); }
		}



    }
}