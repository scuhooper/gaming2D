var speed : float = 1.0;
var animator: Animator;
 
 function Update() {
     var move = Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
     transform.position += move * speed * Time.deltaTime; 

     if(Input.GetAxis("Vertical"))
     {
     	isWalkingDown = true;
     }
 }