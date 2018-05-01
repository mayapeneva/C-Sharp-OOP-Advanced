public class EmergencyRegister
{
    private const int INITIAL_SIZE = 16;

    private IEmergency[] emergencyQueue;

    private int currentSize;

    private int nextIndex;

    public EmergencyRegister()
    {
        this.emergencyQueue = new IEmergency[INITIAL_SIZE];
        this.currentSize = 0;
        this.nextIndex = 0;
    }

    public int Count => this.nextIndex;

    private void IncrementNextIndex()
    {
        this.nextIndex++;
    }

    private void DecrementNextIndex()
    {
        this.nextIndex--;
    }

    private void IncrementCurrentSize()
    {
        this.currentSize++;
    }

    private void DecrementCurrentSize()
    {
        this.currentSize--;
    }

    private void CheckIfResizeNeeded()
    {
        if (this.currentSize == this.emergencyQueue.Length)
        {
            this.Resize();
        }
    }

    private void Resize()
    {
        IEmergency[] newArray = new IEmergency[2 * this.currentSize];

        for (int i = 0; i < this.currentSize; i++)
        {
            newArray[i] = this.emergencyQueue[i];
        }

        this.emergencyQueue = newArray;
    }

    public void EnqueueEmergency(IEmergency emergency)
    {
        this.CheckIfResizeNeeded();

        this.emergencyQueue[this.nextIndex] = emergency;
        this.IncrementNextIndex();

        this.IncrementCurrentSize();
    }

    public IEmergency DequeueEmergency()
    {
        IEmergency removedElement = this.emergencyQueue[0];

        for (int i = 0; i < this.currentSize - 1; i++)
        {
            this.emergencyQueue[i] = this.emergencyQueue[i + 1];
        }

        this.DecrementNextIndex();
        this.DecrementCurrentSize();

        return removedElement;
    }

    public IEmergency PeekEmergency()
    {
        IEmergency peekedElement = this.emergencyQueue[0];
        return peekedElement;
    }

    public bool IsEmpty()
    {
        return this.currentSize == 0;
    }
}