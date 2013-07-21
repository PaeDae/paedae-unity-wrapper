//
//  PaeDaeUnity.mm
//
//
//  Created by Greg Morrison on 11/13/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.
//

#import "PaeDaeUnity.h"
#import "PaeDaeSDK.h"
#import "PaeDaeSharedDelegate.h"

@implementation PaeDaeUnity


@end

extern "C"
{
    void _PaeDaeWrapperInit(const char* key, const char *gameObjectName)
    {
	    [PaeDaeSharedDelegate sharedDelegate].gameObjectName = [NSString stringWithUTF8String:gameObjectName];
        
        [[PaeDaeSDK sharedManager] initWithKey:[NSString stringWithUTF8String:key] andDelegate:[PaeDaeSharedDelegate sharedDelegate]];
    }
    
    void _PaeDaeWrapperShowAd(const char *zoneId, const char *gameObjectName)
    {
	    [PaeDaeSharedDelegate sharedDelegate].gameObjectName = [NSString stringWithUTF8String:gameObjectName];
	    
        NSDictionary *options = [NSDictionary dictionaryWithObjectsAndKeys:
                                   [NSString stringWithUTF8String:zoneId], @"zone_id"
                                   , nil];
                                   
        [[PaeDaeSDK sharedManager] showAdWithOptions:options andDelegate:[PaeDaeSharedDelegate sharedDelegate]];
    }
}
