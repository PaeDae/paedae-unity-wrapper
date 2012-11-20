//
//  PaeDaeUnityImpl.mm
//  
//
//  Created by Greg Morrison on 11/13/12.
//
//

#import "PaeDaeUnityImpl.h"
#import "PaeDaeSharedInitDelegate.h"
#import "PaeDaeSharedPrizeDelegate.h"

@implementation PaeDaeUnityImpl

- (id)init
{
    self = [super init];
    if (self) {
        
    }

    return self;
}

- (void)dealloc
{
    [super dealloc];
}

@end

extern "C"
{
    void _InitWithKey()
    {
        [[PaeDaePrizeSDK sharedManager] initWithKey:@"b00015e0-5cf7-012f-c818-12313f04f84c" andDelegate:[PaeDaeSharedInitDelegate sharedDelegate]];
    }
    
    void _ShowPrizeWithOptionsAndDelegate()
    {
        [[PaeDaePrizeSDK sharedManager] showPrizeWithDelegate: [PaeDaeSharedPrizeDelegate sharedDelegate]];
    }

    void _UpdatePlayerInfo()
    {
    
    }
}