namespace SpecificDataStructures;

public class Property
{
    private Action check;
    private bool status;
    public bool isChecked;

    public bool Status
    {
        get
        {
            if (!isChecked)
                Update();

            return status;
        }
        set { status = value; }
    }

    public Property(Action checkingMethod)
    {
        status = false;
        isChecked = false;
        check = checkingMethod;
    }

    private void Update()
    {
        check();
        isChecked = true;
    }
};