using System.Collections;

public interface IAutoRotatable 
{
    public IEnumerator RotateOnItsOwnAxis();
    public void CallRotation();
}
