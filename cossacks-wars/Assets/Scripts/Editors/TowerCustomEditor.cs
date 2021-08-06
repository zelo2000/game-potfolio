using Assets.Scripts.Enums;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editors
{
    [CustomEditor(typeof(Tower)), CanEditMultipleObjects]
    public class TowerCustomEditor : Editor
    {
        public SerializedProperty Script;

        public SerializedProperty Range;
        public SerializedProperty TurnSpeed;

        public SerializedProperty EnemyTag;
        public SerializedProperty PartToRotate;
        public SerializedProperty FirePoint;

        public SerializedProperty TypeField;

        public SerializedProperty FireRate;
        public SerializedProperty BulletPrefab;

        public SerializedProperty DamageOverTime;
        public SerializedProperty Debuff;
        public SerializedProperty LineRenderer;
        public SerializedProperty ImpactEffect;
        public SerializedProperty ImpactLight;

        void OnEnable()
        {
            Script = serializedObject.FindProperty("m_Script");

            Range = serializedObject.FindProperty("Range");
            TurnSpeed = serializedObject.FindProperty("TurnSpeed");

            EnemyTag = serializedObject.FindProperty("EnemyTag");
            PartToRotate = serializedObject.FindProperty("PartToRotate");
            FirePoint = serializedObject.FindProperty("FirePoint");

            TypeField = serializedObject.FindProperty("Type");

            FireRate = serializedObject.FindProperty("FireRate");
            BulletPrefab = serializedObject.FindProperty("BulletPrefab");

            DamageOverTime = serializedObject.FindProperty("DamageOverTime");
            Debuff = serializedObject.FindProperty("Debuff");
            LineRenderer = serializedObject.FindProperty("LineRenderer");
            ImpactEffect = serializedObject.FindProperty("ImpactEffect");
            ImpactLight = serializedObject.FindProperty("ImpactLight");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(Script);
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(Range);
            EditorGUILayout.PropertyField(TurnSpeed);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Unity Setup", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(EnemyTag);
            EditorGUILayout.ObjectField(PartToRotate, typeof(Transform), new GUIContent("Part To Rotate"));
            EditorGUILayout.ObjectField(FirePoint, typeof(Transform), new GUIContent("Fire Point"));
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Shell", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(TypeField);

            TowerShellType st = (TowerShellType)TypeField.intValue;

            switch (st)
            {
                case TowerShellType.Bullet:
                    EditorGUILayout.ObjectField(BulletPrefab, typeof(GameObject), new GUIContent("Bullet Prefab"));
                    EditorGUILayout.Slider(FireRate, 0, 2, "Fire Rate");
                    break;

                case TowerShellType.Laser:
                    EditorGUILayout.IntSlider(DamageOverTime, 0, 100, new GUIContent("Damage Over Time"));
                    EditorGUILayout.PropertyField(Debuff);
                    EditorGUILayout.ObjectField(LineRenderer, typeof(LineRenderer), new GUIContent("Line Renderer"));
                    EditorGUILayout.ObjectField(ImpactEffect, typeof(ParticleSystem), new GUIContent("Impact Effect"));
                    EditorGUILayout.ObjectField(ImpactLight, typeof(Light), new GUIContent("Impact Light"));
                    break;
            }
            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
