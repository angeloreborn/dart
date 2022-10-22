import OperatingSystem, { UserInfo } from 'os'

export const GetUserInfo : () => UserInfo<string> = () =>  {
  console.log("ok")
  return OperatingSystem.userInfo();
}
