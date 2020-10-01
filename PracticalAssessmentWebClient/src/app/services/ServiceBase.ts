import { isDevMode } from '@angular/core';

export default abstract class ServiceBase {
    protected get baseUrl(): string {
        return isDevMode()
        ? 'http://localhost:50337/api/'
        : 'https://pa-api.vcartera.info/api/'
    }
}