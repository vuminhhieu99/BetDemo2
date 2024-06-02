import { environment } from "src/environments/environment";

export const AppVariable = {
    UrlI18n : `${environment.baseUrlApp}assets/language`,
    Emoji : `${environment.baseUrlApp}assets/emoji/emoji.json`,
    UrlConfig : `${createUrlConfig(environment.env)}`

}

function createUrlConfig(env: string){
    return `${environment.baseUrlApp}assets/env/config.${env}.json`
}