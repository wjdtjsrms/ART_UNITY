﻿using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEditor.XR.Interaction.Toolkit
{
    /// <summary>
    /// Custom editor for an <see cref="ActionBasedController"/>.
    /// </summary>
    [CustomEditor(typeof(ActionBasedController), true), CanEditMultipleObjects]
    [MovedFrom("UnityEngine.XR.Interaction.Toolkit")]
    public class ActionBasedControllerEditor : XRBaseControllerEditor
    {
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="ActionBasedController.positionAction"/>.</summary>
        protected SerializedProperty m_PositionAction;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="ActionBasedController.rotationAction"/>.</summary>
        protected SerializedProperty m_RotationAction;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="ActionBasedController.selectAction"/>.</summary>
        protected SerializedProperty m_SelectAction;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="ActionBasedController.activateAction"/>.</summary>
        protected SerializedProperty m_ActivateAction;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="ActionBasedController.uiPressAction"/>.</summary>
        protected SerializedProperty m_UIPressAction;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="ActionBasedController.hapticDeviceAction"/>.</summary>
        protected SerializedProperty m_HapticDeviceAction;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="ActionBasedController.rotateAnchorAction"/>.</summary>
        protected SerializedProperty m_RotateAnchorAction;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="ActionBasedController.translateAnchorAction"/>.</summary>
        protected SerializedProperty m_TranslateAnchorAction;

        /// <summary>
        /// Contents of GUI elements used by this editor.
        /// </summary>
        protected static class Contents
        {
            /// <summary><see cref="GUIContent"/> for <see cref="ActionBasedController.positionAction"/>.</summary>
            public static GUIContent positionAction = EditorGUIUtility.TrTextContent("Position Action", "The Input System action to use for Position Tracking for this GameObject. Must be a Vector3 Control.");
            /// <summary><see cref="GUIContent"/> for <see cref="ActionBasedController.rotationAction"/>.</summary>
            public static GUIContent rotationAction = EditorGUIUtility.TrTextContent("Rotation Action", "The Input System action to use for Rotation Tracking for this GameObject. Must be a Quaternion Control.");
            /// <summary><see cref="GUIContent"/> for <see cref="ActionBasedController.selectAction"/>.</summary>
            public static GUIContent selectAction = EditorGUIUtility.TrTextContent("Select Action", "The Input System action to use for Selecting an Interactable. Must be a Button Control.");
            /// <summary><see cref="GUIContent"/> for <see cref="ActionBasedController.activateAction"/>.</summary>
            public static GUIContent activateAction = EditorGUIUtility.TrTextContent("Activate Action", "The Input System action to use for Activating a selected Interactable. Must be a Button Control.");
            /// <summary><see cref="GUIContent"/> for <see cref="ActionBasedController.uiPressAction"/>.</summary>
            public static GUIContent uiPressAction = EditorGUIUtility.TrTextContent("UI Press Action", "The Input System action to use for UI interaction. Must be a Button Control.");
            /// <summary><see cref="GUIContent"/> for <see cref="ActionBasedController.hapticDeviceAction"/>.</summary>
            public static GUIContent hapticDeviceAction = EditorGUIUtility.TrTextContent("Haptic Device Action", "The Input System action to use for identifying the device to send haptic impulses to. Can be any control type that will have an active control driving the action.");
            /// <summary><see cref="GUIContent"/> for <see cref="ActionBasedController.rotateAnchorAction"/>.</summary>
            public static GUIContent rotateAnchorAction = EditorGUIUtility.TrTextContent("Rotate Anchor Action", "The Input System action to use for rotating the interactor's attach point. Must be a Vector2 Control. Will use the X-axis as the rotation input.");
            /// <summary><see cref="GUIContent"/> for <see cref="ActionBasedController.translateAnchorAction"/>.</summary>
            public static GUIContent translateAnchorAction = EditorGUIUtility.TrTextContent("Translate Anchor Action", "The Input System action to use for translating the interactor's attach point closer or further away from the interactor. Must be a Vector2 Control. Will use the Y-axis as the translation input.");
        }

        /// <inheritdoc />
        protected override void OnEnable()
        {
            base.OnEnable();

            m_PositionAction = serializedObject.FindProperty("m_PositionAction");
            m_RotationAction = serializedObject.FindProperty("m_RotationAction");
            m_SelectAction = serializedObject.FindProperty("m_SelectAction");
            m_ActivateAction = serializedObject.FindProperty("m_ActivateAction");
            m_UIPressAction = serializedObject.FindProperty("m_UIPressAction");
            m_HapticDeviceAction = serializedObject.FindProperty("m_HapticDeviceAction");
            m_RotateAnchorAction = serializedObject.FindProperty("m_RotateAnchorAction");
            m_TranslateAnchorAction = serializedObject.FindProperty("m_TranslateAnchorAction");
        }

        /// <inheritdoc />
        protected override void DrawTrackingConfiguration()
        {
            base.DrawTrackingConfiguration();
            EditorGUILayout.PropertyField(m_PositionAction, Contents.positionAction);
            EditorGUILayout.PropertyField(m_RotationAction, Contents.rotationAction);
        }

        /// <inheritdoc />
        protected override void DrawInputConfiguration()
        {
            base.DrawInputConfiguration();
            EditorGUILayout.PropertyField(m_SelectAction, Contents.selectAction);
            EditorGUILayout.PropertyField(m_ActivateAction, Contents.activateAction);
            EditorGUILayout.PropertyField(m_UIPressAction, Contents.uiPressAction);
        }

        /// <inheritdoc />
        protected override void DrawOtherActions()
        {
            base.DrawOtherActions();
            EditorGUILayout.PropertyField(m_HapticDeviceAction, Contents.hapticDeviceAction);
            EditorGUILayout.PropertyField(m_RotateAnchorAction, Contents.rotateAnchorAction);
            EditorGUILayout.PropertyField(m_TranslateAnchorAction, Contents.translateAnchorAction);
        }
    }
}
