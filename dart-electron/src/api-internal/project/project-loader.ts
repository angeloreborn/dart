//Copyright © 2022 Dart - All rights reserved

/** Imports ***************************************************/
import {
  GetUserInfo
} from 'extentions/os.extention';

/** Exports ***************************************************/
export interface IProjectLoader{
  SearchProject(opt: IProjectLoaderOptions): IProjectMetaData[]
  GetActiveWindowsUser(opt: IGetActiveWindowsUserOptions): string
}

export interface IProjectMetaData{
   projectName: string
   projectDate: Date
}

export interface IProjectLoaderOptions{
}

export interface IGetActiveWindowsUserOptions{

}

/**
 * @os Windows
 * @returns Username of the windows user
 */
export const GetActiveWindowsUser : () => string = () => {
  let userInfo = GetUserInfo();
  console.log(userInfo);
  return userInfo.username;
}

export const SearchProject = () =>{

}


