using CosmicCuration.Bullets;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private Bulletpool bulletPool;

        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
            playerController = new PlayerController(playerViewPrefab, playerScriptableObject, bulletPrefab, bulletScriptableObject);
            bulletPool = new Bulletpool(bulletPrefab, bulletScriptableObject);
        }

        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();
        
    } 
}