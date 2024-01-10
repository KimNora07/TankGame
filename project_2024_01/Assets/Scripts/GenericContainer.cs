
public class GenericContainer<T>
{
    private T[] Items;              // 제너릭 배열 생성
    //private List<> itemList;   
    private int currentIndex = 0;   // 배열 Index 선언

    public GenericContainer(int capacity){  // 생성이 될 때 숫자를 받아와서 배열 갯수를 만든다.
        Items = new T[capacity];
    }

    public void Add(T Item){                // 배열에 데이터를 넣는 함수
        if(currentIndex < Items.Length){    // 배열의 길이를 검사
            Items[currentIndex] = Item;     // 배열의 index에 맞게 배열에 넣는다.
            currentIndex++;
        }
    }

    public T[] GetItems(){
        return Items;
    }
}
