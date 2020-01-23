using System.Collections;
using System.Collections.Generic;

//This is an interface for consumable items
public interface IConsumables {

    void consume(); //consume item

    //This will take character stats and allow consumed item to effect character's stats
    void consume(CharacterStat stats);
}