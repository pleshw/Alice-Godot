using System.Numerics;
using Game;

namespace Build;

public class PlayerActorBuild : EntityActorBuild<PlayerEntity>
{
    private static PlayerEntity? _playerActor;

    public override PlayerEntity Actor
    {
        get
        {
            _playerActor ??= new("PlayerActor")
            {
                SaveFolder = "testSaveFolder"
            };

            return _playerActor!;
        }
    }
}