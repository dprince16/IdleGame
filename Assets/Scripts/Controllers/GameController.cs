﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Models;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Diagnostics;
using Assets.Scripts.Services;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        private static GameService _gameService;

        #region Unity Methods

        void Awake()
        {
            //PlayerPrefs.DeleteAll();
            _gameService = GetComponent<GameService>();
        }

        void Start()
        {
            Load();
            HideMenus();
            DisplayOfflineEarnings();
            RefreshCanvas();
            InvokeRepeating("Save", 0, 1);
            InvokeRepeating("CheckEnableButtons", 0, .1f);
        }

        #endregion

        #region Public Methods

        public void Buy(int index)
        {
            _gameService.Buy(index);
        }

        public void WorkShop(int index)
        {
            _gameService.WorkShop(index);
        }

        public void ChangeBuyMultiple()
        {
            _gameService.ChangeBuyMultiple();
        }

        public void OpenMenu(GameObject menu)
        {
            menu.transform.parent.transform.SetAsLastSibling();
            menu.SetActive(true);
        }

        public void CloseMenu(GameObject menu)
        {
            menu.SetActive(false);
        }

        #endregion

        #region Private Methods
        private void Save()
        {
            _gameService.Save();
        }

        private void Load()
        {
            _gameService.Load();
        }

        private void DisplayOfflineEarnings()
        {
            _gameService.DisplayOfflineEarnings();
        }

        private void CheckEnableButtons()
        {
            _gameService.CheckEnableButtons();
        }

        private void HideMenus()
        {
            _gameService.HideMenus();
        }

        private void RefreshCanvas()
        {
            _gameService.RefreshCanvas();
        }
        #endregion
    }
}
