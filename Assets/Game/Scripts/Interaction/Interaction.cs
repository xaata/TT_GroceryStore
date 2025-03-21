using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class Interaction
    {
        public static List<T> RaycastFindAll<T>(Transform camera, float distance) where T : Component
        {
            List<T> results = new List<T>();
            Ray ray = new Ray(camera.position, camera.forward);
            Debug.DrawRay(camera.position, camera.forward * distance, Color.red);

            RaycastHit[] hits = Physics.RaycastAll(ray, distance);

            foreach (var hit in hits)
            {
                T component = hit.collider.GetComponent<T>();
                if (component != null)
                {
                    results.Add(component);
                    Debug.Log($"Found: {hit.collider.name}");
                }
            }

            return results;
        }

        public static List<T> SphereCastFindAll<T>(Transform camera, float radius, float distance) where T : Component
        {
            List<T> results = new List<T>();
            Ray ray = new Ray(camera.position, camera.forward);
            Debug.DrawRay(camera.position, camera.forward * distance, Color.green);

            RaycastHit[] hits = Physics.SphereCastAll(ray, radius, distance);

            foreach (var hit in hits)
            {
                T component = hit.collider.GetComponent<T>();
                if (component != null)
                {
                    results.Add(component);
                    //Debug.Log($"Found: {hit.collider.name}");
                }
            }

            return results;
        }

        public static List<T> CapsuleCastFindAll<T>(Transform camera, float radius, float height, float distance) where T : Component
        {
            List<T> results = new List<T>();
            Vector3 point1 = camera.position + camera.up * (height / 2 - radius);
            Vector3 point2 = camera.position - camera.up * (height / 2 - radius);
            Debug.DrawLine(point1, point2, Color.blue);

            RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, radius, camera.forward, distance);

            foreach (var hit in hits)
            {
                T component = hit.collider.GetComponent<T>();
                if (component != null)
                {
                    results.Add(component);
                    Debug.Log($"Found: {hit.collider.name}");
                }
            }

            return results;
        }

        public static T FindClosestToCenter<T>(List<T> objects, Transform camera) where T : Component
        {
            T closest = null;
            float closestDistance = float.MaxValue;

            foreach (var obj in objects)
            {
                Vector3 screenPoint = Camera.main.WorldToScreenPoint(obj.transform.position);
                float distanceToCenter = Vector2.Distance(new Vector2(screenPoint.x, screenPoint.y), new Vector2(Screen.width / 2, Screen.height / 2));

                if (distanceToCenter < closestDistance)
                {
                    closest = obj;
                    closestDistance = distanceToCenter;
                }
            }

            return closest;
        }
        public static T FindClosestToTransform<T>(List<T> objects, Transform referenceTransform) where T : Component
        {
            T closest = null;
            float closestDistance = float.MaxValue;

            foreach (var obj in objects)
            {
                float distance = Vector3.Distance(referenceTransform.position, obj.transform.position);

                if (distance < closestDistance)
                {
                    closest = obj;
                    closestDistance = distance;
                }
            }

            return closest;
        }
    }
}