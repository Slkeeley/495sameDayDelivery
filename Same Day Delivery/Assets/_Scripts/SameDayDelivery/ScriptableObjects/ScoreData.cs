using UnityEngine;

namespace SameDayDelivery.ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "ScoreData", menuName = "Game/ScoreData", order = 51)]
    public class ScoreData : ScriptableObject
    {
        [Header("Completed Delivery")]
        [Min(0), Tooltip("How much a standard, unmodified delivery is worth.")]
        public int baseDeliveryScore = 100;
        
        [Min(0), Tooltip("How much to award for a speedy delivery.")]
        public int speedyBonus = 50;
        
        [Min(0), Tooltip("How much to penalize for a slow delivery.")]
        public int slowPenalty = 50;
        
        [Min(0), Tooltip("How much to penalize for a damaged package.")]
        public int damagedPackagePenalty = 25;

        [Min(0), Tooltip("How much to award for style points.")]
        public int styleBonus = 25;
        
        [Min(0), Tooltip("Color of the text displayed with Speedy Deliveries")]
        public Color normalDeliveryColor = Color.white;
        
        [Min(0), Tooltip("Color of the text displayed with Speedy Deliveries")]
        public Color speedyDeliveryColor = Color.cyan;
        
        [Min(0), Tooltip("Color of the text displayed with Speedy Deliveries")]
        public Color slowDeliveryColor = Color.red;

        [Header("Completed Day")]
        [Min(0), Tooltip("How much score per coin to award the player at the end of the level.")]
        public int coinScoreReward = 50;
        
        [Header("Completed Side Job")]
        [Min(0), Tooltip("How much score to award the player for a successful side job.")]
        public int sideJobScoreBonus = 5;
        
        [Min(0), Tooltip("How many coins to award the player for a successful side job.")]
        public int sideJobCoinBonus = 1;
    }
}